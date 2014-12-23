using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
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
        public IBroker Seller { get; private set; }
        public string SecurityId { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }
        public Guid Id { get; private set; }

    }
}
