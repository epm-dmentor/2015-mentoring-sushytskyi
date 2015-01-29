using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class EmFeedManager : IFeedManager
    {
        public IEnumerable<ValidationError> Validate(TradeFeedItem item)
        {
            var errorsList = new List<ValidationError>();
            var emItem = item as EmTradeFeedItem;
            if (emItem == null)
            {
                errorsList.Add(new ValidationError("item is not EmFeedItem"));
                return errorsList;
            }
            var error = ZeroAccountCheck(emItem);

            if (error != null)
            {
                errorsList.Add(error);
            }
            return errorsList;
        }

        private ValidationError ZeroAccountCheck(TradeFeedItem item)
        {
            var emItem = item as EmTradeFeedItem;
            if (emItem == null)
                throw new ApplicationException("Not Em Item");

            if (emItem.SourceAccountId == 0)
                return new ValidationError(String.Format("Zero account found for trade ref: {0}", emItem.SourceTradeRef));
            return null;
        }

        public string Match(TradeFeedItem item)
        {
            var emItem = item as EmTradeFeedItem;
            if (emItem == null)
                return String.Empty;

            return String.Format(emItem.SourceAccountId + "-EM_FEED");
        }


        public Guid Save(TradeFeedItem item)
        {
            var emItem = item as EmTradeFeedItem;
            if (emItem == null)
                throw new ApplicationException("Not EM Item");
            Console.WriteLine("D1 feed Saved");
            return Guid.NewGuid();
        }
    }
}
