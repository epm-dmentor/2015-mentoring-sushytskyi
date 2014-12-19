using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
  public class BuyRecord
    {
      public BuyRecord(IBroker buyer, string securityId, int ammount, int price)
        {
            // TODO: Complete member initialization
            this.Buyer = buyer;
            this.SecurityId = securityId;
            this.Amount = ammount;
            this.Price = price;
            BuyRecords.Add(this);

        }
        public IBroker Buyer { get; set; } 
        public string SecurityId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public Guid MatchedSellId { get; set; }
        public static List<BuyRecord> BuyRecords =new List<BuyRecord>(); 

      public SellRecord MatchedSellRecord 
      {
          get {return SellRecord.SellRecords.Find((s)=>s.MatchedBuyId==this.MatchedSellId); }
      }
    }
}
