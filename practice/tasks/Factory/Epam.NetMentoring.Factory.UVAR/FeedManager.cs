using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    class FeedManager : IFeedManager
    {
        public IEnumerable<string> Validate(ITradeFeedItem item)
        {
            Console.WriteLine("this is base validation");
            return new List<string>();
        }

        public string Match(ITradeFeedItem item)
        {
            Console.WriteLine("this is base Matching");
            return "";
        }

        public bool Save(ITradeFeedItem item)
        {
            Console.WriteLine("this is base saving");
            return true;
        }
    }
}
