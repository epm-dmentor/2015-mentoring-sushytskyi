using System.Collections.Generic;

namespace Epam.NetMentoring.Config
{
    internal interface IConfigFile
    {
        List<Setting> Settings { get; }
        string FileName { get; }
    }
}