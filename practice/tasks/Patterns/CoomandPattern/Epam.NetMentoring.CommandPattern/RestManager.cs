using System.Net;

namespace Epam.NetMentoring.CommandPattern
{
    public class RestManager
    {
        public string GetRestContent(string url)
        {
            using (WebClient client = new WebClient())
            {
                string result = "";
                result = client.DownloadString(url);
                return result;
            }
        }
    }
}
