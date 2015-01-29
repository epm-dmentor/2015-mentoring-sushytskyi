using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    class FeedManager : IFeedManager
    {
        public IEnumerable<ValidationError> Validate(TradeFeedItem item)
        {
            Console.WriteLine("this is base validation");
            return new List<ValidationError>();
        }

        public string Match(TradeFeedItem item)
        {
            Console.WriteLine("this is base Matching");
            return String.Empty;
        }

        public Guid Save(TradeFeedItem item)
        {
            Console.WriteLine("this is base saving");
            return Guid.Empty;
        }
    }
}
