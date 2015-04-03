using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    //IT: do in the similar way everywhere
    public class Delta1FeedManager : IFeedManager
    {
        public IEnumerable<ValidationError> Validate(TradeFeedItem item)
        {
            var d1Item = ConvertToDeltaOne(item);

            var errorsList = new List<ValidationError>();

            if (String.IsNullOrWhiteSpace(d1Item.Market))
                errorsList.Add( new ValidationError(String.Format("Zero Market not found for ref: {0}", d1Item.SourceTradeRef)));

            return errorsList;
        }

        private static Delta1TradeFeedItem ConvertToDeltaOne(TradeFeedItem item)
        {
            var d1Item = item as Delta1TradeFeedItem;
            if (d1Item == null)
            {
                throw new ArgumentException(String.Format("Item is not of DeltaOne type, real time is: {0}", item.GetType()));
            }

            return d1Item;
        }

        public string Match(TradeFeedItem item)
        {
            var d1Item = ConvertToDeltaOne(item);

            return String.Format("{0}-{1}-{2}", d1Item.SourceAccountId, d1Item.CounterpartyId, d1Item.PrincipalId);
        }

        public Guid Save(TradeFeedItem item)
        {
            var d1Item = ConvertToDeltaOne(item);

            Console.WriteLine("D1 feed Saved");
            return Guid.NewGuid();
        }

    }
}
