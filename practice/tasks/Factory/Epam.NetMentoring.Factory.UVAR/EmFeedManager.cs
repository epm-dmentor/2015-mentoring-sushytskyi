using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class EmFeedManager : IFeedManager
    {
        public IEnumerable<string> Validate(ITradeFeedItem item)
        {
            var errorsList = new List<string>();
            var emItem = item as EmTradeFeedItem;
            if (emItem == null)
            {
                errorsList.Add("item is not EmFeedItem");
                return errorsList;
            }
            var error = ZeroAccountCheck(emItem);

            if (error != String.Empty)
            {
                errorsList.Add(error);
            }
            return errorsList;
        }

        private string ZeroAccountCheck(ITradeFeedItem item)
        {
            var emItem = item as EmTradeFeedItem;
            if (emItem == null)
                return "";

            if (emItem.SourceAccountId == 0)
                return String.Format("Zero account found for trade ref: {0}", emItem.SourceTradeRef);
            return "";
        }

        public string Match(ITradeFeedItem item)
        {
            var emItem = item as EmTradeFeedItem;
            if (emItem == null)
                return "";

            return emItem.SourceAccountId + "-EM_FEED";
        }


        public bool Save(ITradeFeedItem item)
        {
            var emItem = item as EmTradeFeedItem;
            return emItem == null;
        }
    }
}
