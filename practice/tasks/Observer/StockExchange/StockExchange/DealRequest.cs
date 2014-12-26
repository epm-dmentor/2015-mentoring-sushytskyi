using System;
//IT: unused namespaces!

namespace Epam.NetMentoring.StockExchange
{
    public enum DealType
    {
        Sell,
        Buy
    }

    //IT: it can be generalized for our case: DealRequest
    class DealRequest
    {
        public DealRequest(IBroker seller, string securityId, int ammount, decimal price, DealType dealType)
        {
            this.Seller = seller;
            this.SecurityId = securityId;
            this.Amount = ammount;
            this.Price = price;
            this.DealType = dealType;
            Id = Guid.NewGuid();
        }
        //IT: for generalized version Broker
        public IBroker Seller { get; private set; }
        public string SecurityId { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }
        public DealType DealType { get; private set; }
        public Guid Id { get; private set; }

        //IT: For generalized version we need to add DealType=either Buy or Sell

    }
}
