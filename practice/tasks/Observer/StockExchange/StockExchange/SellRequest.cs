using System;
using System.Collections.Generic;
//IT: unused namespaces!

namespace Epam.NetMentoring.StockExchange
{

    //IT: it can be generalized for our case: DealRequest
    public class SellRequest
    {
      public SellRequest(IBroker seller, string securityId, int ammount, decimal price)
        {
            this.Seller = seller;
            this.SecurityId = securityId;
            this.Amount = ammount;
            this.Price = price;
            Id = Guid.NewGuid();
        }
        //IT: for generalized version Broker
        public IBroker Seller { get; private set; }
        public string SecurityId { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }
        public Guid Id { get; private set; }

        //IT: For generalized version we need to add DealType=either Buy or Sell

    }
}
