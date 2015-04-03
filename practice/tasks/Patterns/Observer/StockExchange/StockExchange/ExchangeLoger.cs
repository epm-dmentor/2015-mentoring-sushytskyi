using System;

namespace Epam.NetMentoring.StockExchange
{
    //IT2: It might be names as Listener, but it's better to use more evidend name
    // do not sea the reason to do it internal
    public class ExchangeLogger : IStockExchangeListener
    {
        public void OnSold(DealInfo info)
        {
            Console.WriteLine("New Deal: Security {0} | Ammount {1} | Price {2}| ",
                info.SecurityId, info.Ammount, info.Price);
        }

        public void OnRequestSelling(DealInfo info)
        {
            Console.WriteLine("New sell requested: Security {0} | Ammount {1} | Price {2}| ",
                info.SecurityId, info.Ammount, info.Price);
        }
    }
}
