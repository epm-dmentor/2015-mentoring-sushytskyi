using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.NetMentoring.Config
{
    class ConfigFile : IConfigFile
    {
        private List<Setting> _settings;

        public List<Setting> Settings
        {
            get
            {
                if (_settings != null)
                    return _settings;
                _settings = Parse();
                return _settings;
            }
        }
        public string FileName { get; private set; }

        public ConfigFile(string fileName)
        {
            FileName = fileName;
        }
        private List<Setting> Parse()
        {
            var settings = new List<Setting>();
            string line = "";

            try
            {
                //Read file line by line, splite line by "=" to get setting value
                //Then split first item in array by "." to get class path List. 
                using (var r = new StreamReader(FileName))
                {
                    while ((line = r.ReadLine()) != null)
                    {
                        if (!String.IsNullOrEmpty(line))
                        {
                            var strSplitedByEqual = line.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                            var classPathsplitedByDot = strSplitedByEqual[0].Split('.');

                            if (classPathsplitedByDot.Length > 0 && strSplitedByEqual.Length > 1)
                                settings.Add(new Setting()
                                {
                                    PathList = classPathsplitedByDot.ToList(),
                                    SettingName = classPathsplitedByDot[classPathsplitedByDot.Length - 1],
                                    SettingValue = strSplitedByEqual[1]
                                });

                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return settings;
        }
    }
}
