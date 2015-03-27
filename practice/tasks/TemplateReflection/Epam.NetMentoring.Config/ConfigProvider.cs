using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Epam.NetMentoring.Config
{
    class ConfigProvider : IConfigProvider
    {
        private readonly IConfigFile _config;
        public ConfigProvider(IConfigFile configFile)
        {
            _config = configFile;
        }

        public T Resolve<T>() where T : new()
        {
            var obj = new T();
            var typeFullName = typeof(T).FullName;

            foreach (var prop in typeof(T).GetProperties())
            {
                var propPathArray = (typeFullName + "." + prop.Name).Split('.');

                //get settings with mathing name and class path less then prop class path (kinda dirty filtering)
                var settingsList = _config.Settings.FindAll(s => s.SettingName == prop.Name && s.PathList.Count <= propPathArray.Length);

                //clean filtering select the best match setting
                //usage: 
                //settingsList: dirty filtered setting list
                //propPathArray: full prop path
                //shift: position to start look up from the end of the list if 1 prop name ignored
                var bestMatchedSetting = BestMatchFilter(settingsList, propPathArray, 1);
                if (bestMatchedSetting.Count > 0)
                    try
                    {
                        prop.SetValue(obj, Convert.ChangeType(bestMatchedSetting.FirstOrDefault().SettingValue, prop.PropertyType, CultureInfo.InvariantCulture));
                    }
                    catch (FormatException ex)
                    {

                        Console.WriteLine(
                            "Property: {0} , Value Conversion failed, ExpectedType: {1} Received Value: {2} , Exception: {3}"
                            , bestMatchedSetting.FirstOrDefault().SettingName
                            , prop.PropertyType
                            , bestMatchedSetting.FirstOrDefault().SettingValue
                            , ex);
                    }
            }

            return obj;
        }

        private List<Setting> BestMatchFilter(List<Setting> filteredSettings, string[] propFullPath, int shift)
        {
            var removed = new List<Setting>();
            bool itterated = false;

            //matches arrays of prop path with array of setting path by one item at cycle starting from end
            //If matched setting passed on next itteration if not removed from setting list
            foreach (Setting matchedProp in filteredSettings)
            {
                if (matchedProp.PathList.Count - shift >= 0)
                    if (matchedProp.PathList[matchedProp.PathList.Count - shift] ==
                        propFullPath[propFullPath.Length - shift])
                    {
                        if (!filteredSettings.Contains(matchedProp))
                            filteredSettings.Add(matchedProp);
                        itterated = true;
                    }
                    else
                    {
                        //remove only those which are not matched by items 
                        //and leave those which are not matching by lenght of arrays
                        removed.Add(filteredSettings.Find(s => s == matchedProp));
                    }
            }
            removed.ForEach(s => filteredSettings.Remove(s));

            if (itterated)
            {
                shift++;

                //next iteration
                filteredSettings = BestMatchFilter(filteredSettings, propFullPath, shift);
            }

            //sort asceding and return the onle which has longest correct class path
            var sorted = filteredSettings.OrderBy(setting => setting.PathList.Count).Last();
            return new List<Setting>() { sorted };
        }

    }
}
