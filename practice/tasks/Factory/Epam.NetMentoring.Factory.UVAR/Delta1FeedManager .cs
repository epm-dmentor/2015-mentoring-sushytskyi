using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class Delta1FeedManager : IFeedManager
    {
        //IT: it's better to return ValidationError instead of just string
        //IS: revorked below to use custom class to save errors
        public IEnumerable<ValidationError> Validate(TradeFeedItem item)
        {
            var errorsList = new List<ValidationError>();
            var d1Item = item as Delta1TradeFeedItem;
            if (d1Item == null)
            {
                errorsList.Add(new ValidationError("item is not D1FeedItem"));
                return errorsList;
            }
            var error = ZeroMarketCheck(d1Item);

            //IT: String.IsNullOrWhiteSpace
            if (error != null)
            {
                errorsList.Add(error);
            }
            return errorsList;
        }

        private ValidationError ZeroMarketCheck(TradeFeedItem item)
        {
            var d1Item = item as Delta1TradeFeedItem;
            if (d1Item == null)
                //IT: String.Empty
                // return String.Empty;
                throw new ApplicationException("Not Delta1 item");

            //IT: String.Empty
            //IT: String.IsNullOrWhiteSpace() is better            
            if (String.IsNullOrWhiteSpace(d1Item.Market))
                return new ValidationError(String.Format("Zero Market not found for ref: {0}", d1Item.SourceTradeRef));

            //IT: String.Empty
            return null;
        }
        //IT: String.Empty
        public string Match(TradeFeedItem item)
        {
            var d1Item = item as Delta1TradeFeedItem;
            if (d1Item == null)
                return String.Empty;

            //IT: String.Format
            return String.Format(d1Item.SourceAccountId + "" + d1Item.CounterpartyId + "" + d1Item.PrincipalId);
        }

        public Guid Save(TradeFeedItem item)
        {
            var d1Item = item as Delta1TradeFeedItem;
            //IT: Show something in console :) to identify that Delta1 trade saved
            if (d1Item == null)
                throw new ApplicationException("Not D1 feed");
            Console.WriteLine("D1 feed Saved");
            return Guid.NewGuid();
        }

    }
}
