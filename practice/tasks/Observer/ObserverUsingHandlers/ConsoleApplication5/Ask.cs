using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
  public  class Ask
    {
        public string SecCode { get; set; }
        public decimal Price{ get; set; }
        public int Amount { get; set; }
        public Broker Broker { get; set; }
        public Guid ackquireTranId { get; set; }

        public Ask(string secCode,decimal price,int amount, Broker broker)
        {
            this.Amount = amount;
            this.Price = price;
            this.SecCode = secCode;
            this.Broker = broker;
            ackquireTranId = Guid.Empty;
        }
 
    }
}
