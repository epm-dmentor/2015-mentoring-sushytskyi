using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Mailing
{
    public class MapConfig
    {
        private readonly NameValueCollection _imapSection;
        public MapConfig()
        {
            _imapSection = ConfigurationManager.GetSection("imap") as NameValueCollection;

        }
        public string Host
        {
            get
            {
                return _imapSection["host"];

            }
        }
        public int Port
        {
            get
            {
                int result;
                Int32.TryParse(_imapSection["Port"], out result);
                return result;
            }
        }
        public bool Ssl
        {
            get
            {
                bool result;
                Boolean.TryParse(_imapSection["ssl"], out result);
                return result;
            }
        }
        public string Mail
        {
            get
            {

                return _imapSection["mail"];
            }
        }
        public string Password
        {
            get
            {
                return _imapSection["Password"];
            }
        }

    }
}
