using System;

namespace Epam.NetMentoring.StockExchange
{
    class Listener : IStockExchangeListener
    {
        public void OnSold(DealInfo info)
        {
            Console.WriteLine("New Deal: Security {0} | Seller {1} | Buyer {2} | Ammount {3} | Price {4}| ",
                info.SecurityId, info.Seller, info.Buyer, info.Ammount, info.Price
                );
        }

        public void OnRequestSelling(DealInfo info)
        {
            Console.WriteLine("New sell requested: Security {0} | Seller {1} | Buyer {2} | Ammount {3} | Price {4}| ",
                info.SecurityId, info.Seller, info.Buyer, info.Ammount, info.Price
                );
        }
    }
}
