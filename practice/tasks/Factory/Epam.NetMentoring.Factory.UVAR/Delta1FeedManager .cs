using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class Delta1FeedManager : IFeedManager
    {
        public IEnumerable<string> Validate(ITradeFeedItem item)
        {
            var errorsList = new List<string>();
            var d1Item = item as Delta1TradeFeedItem;
            if (d1Item == null)
            {
                errorsList.Add("item is not D1FeedItem");
                return errorsList;
            }
            var error = ZeroMarketCheck(d1Item);

            if (error != String.Empty)
            {
                errorsList.Add(error);
            }

            return errorsList;
        }

        private string ZeroMarketCheck(ITradeFeedItem item)
        {
            var d1Item = item as Delta1TradeFeedItem;
            if (d1Item == null)
                return "";

            if (d1Item.Market == "")
                return String.Format("Zero Market found for ref: {0}", d1Item.SourceTradeRef);
            return "";
        }

        public string Match(ITradeFeedItem item)
        {
            var d1Item = item as Delta1TradeFeedItem;
            if (d1Item == null)
                return "";
            return d1Item.SourceAccountId + "" + d1Item.CounterpartyId + "" + d1Item.PrincipalId;
        }

        public bool Save(ITradeFeedItem item)
        {
            var d1Item = item as Delta1TradeFeedItem;
            return d1Item == null;
        }

    }
}
