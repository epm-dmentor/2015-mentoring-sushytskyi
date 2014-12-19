using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.StockExchange
{
  public class SellRequest
    {
        public SellRecord SellRequestInfo;

        public SellRequest(SellRecord sellRequest)
        {
            // TODO: Complete member initialization
            this.SellRequestInfo = sellRequest;
        }
    }
}
