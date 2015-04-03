using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class EmFeedManager : IFeedManager
    {
        public IEnumerable<ValidationError> Validate(TradeFeedItem item)
        {
            var emItem = ConvertToEm(item);
            var errorsList = new List<ValidationError>();

            if (emItem.SourceAccountId == 0)
                errorsList.Add(new ValidationError(String.Format("Zero Market not found for ref: {0}", emItem.SourceTradeRef)));

            return errorsList;
        }

        private static EmTradeFeedItem ConvertToEm(TradeFeedItem item)
        {
            var EmItem = item as EmTradeFeedItem;
            if (EmItem == null)
            {
                throw new ArgumentException(String.Format("Item is not of Em type, real type is: {0}", item.GetType()));
            }
            return EmItem;
        }

        public string Match(TradeFeedItem item)
        {
            var emItem = ConvertToEm(item);
            return String.Format("{0}-{1}", emItem.SourceAccountId, "-EM_FEED");
        }

        public Guid Save(TradeFeedItem item)
        {
            var emItem = ConvertToEm(item);
            Console.WriteLine("D1 feed Saved");
            return Guid.NewGuid();
        }
    }
}
