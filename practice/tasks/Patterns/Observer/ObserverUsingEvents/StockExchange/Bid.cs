using System;
using ConsoleApplication5;

namespace Epam.NetMentoring.StockExchange
{
   public  class Bid
    {
        public string SecCode { get; set; }
        public decimal Price{ get; set; }
        public int Amount { get; set; }
        public Broker Broker { get; set; }
        public Guid AckquireTranId { get; set; }

        public Bid(string secCode, decimal price, int amount, Broker broker)
        {
            Amount = amount;
            Price = price;
            SecCode = secCode;
            Broker = broker;
            AckquireTranId = Guid.Empty;
        }
    }
}
