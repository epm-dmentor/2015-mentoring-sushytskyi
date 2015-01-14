using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class FeedProcessor
    {
        private readonly IEnumerable<TradeFeed> _feedItems;
        private readonly FeedManagerFactory _feedManager = new FeedManagerFactory();
        public FeedProcessor(IEnumerable<TradeFeed> feedItems)
        {
            _feedItems = feedItems;
        }

        public List<string> ProcessItems()
        {
            var matchingRes = new List<string>();
            foreach (TradeFeed tradeFeed in _feedItems)
            {
                var feedManager = _feedManager.GetFeedManger(tradeFeed);
                var validationErros = new List<string>();
                if (feedManager.TryValidate(out validationErros))
                {
                    matchingRes = feedManager.MatchFeed().ToList();
                }
                else
                {
                    foreach (var erro in validationErros)
                    {
                        Console.WriteLine("Validation Failed for {0}", feedManager.GetType());
                        Console.WriteLine(erro);
                    }
                }
                feedManager.Save();

            }
            return matchingRes;
        }

    }
}
