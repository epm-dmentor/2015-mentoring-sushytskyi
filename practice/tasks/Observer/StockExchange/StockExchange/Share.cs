using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.NetMentoring.StockExchange
{
   public class Share
    {
       public string SecurityId { get; private set; }
       public int Ammount { get; private set; }
       public decimal Price { get; private set; }

       public Share()
       {
           
       }

       public Share(string securityId, int ammount, decimal price)
       {
           // TODO: Complete member initialization
           this.SecurityId = securityId;
           this.Ammount = ammount;
           this.Price = price;
       }
    }
}
