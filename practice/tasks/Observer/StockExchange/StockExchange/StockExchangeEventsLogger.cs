using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.StockExchange
{
    class StockExchangeEventsLogger : IStockExchangeListener
    {
 
        public void OnSold(DealInfo info)
        {
       Console.WriteLine("SOLD > Broker {0}|Stock {1}|Amount {2}|Price {3}|Matched transaction {4}"
      , info.Deal.Seller
      , info.Deal.SecurityId
      , info.Deal.Amount
      , info.Deal.Price
      , info.Deal.MatchedBuyId
      );
 
        }

        public void OnRequestSelling(SellRequest info)
        {
            throw new NotImplementedException();
        }
    }
}
