using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.NetMentoring.CommandPattern
{
    class FileManager
    {
        public string GetFiles(string location)
        {
            var output = Directory.GetFiles(location);
            return output.Aggregate("", (current, s) => current + s + "\r\n");
        }
    }
}
