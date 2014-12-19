using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
  public class SellRecord
    {
      public SellRecord(IBroker seller, string securityId, int ammount, int price)
        {
            // TODO: Complete member initialization
            this.Seller = seller;
            this.SecurityId = securityId;
            this.Amount = ammount;
            this.Price = price;
            SellRecords.Add(this);

        }
        public IBroker Seller { get; set; }
        public string SecurityId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public Guid MatchedBuyId { get; set; }
        public static List<SellRecord> SellRecords = new List<SellRecord>(); 

    }
}
