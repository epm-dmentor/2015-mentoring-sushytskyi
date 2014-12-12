using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
   public  interface IInformer
    {
        List<Ask> OpenAsks { set; get; }
        List<Bid> OpenBids { set; get; }
        List<Ask> BuysConfirmedlist { set; get; }
        List<Bid> SoldList { set; get; }
       void PrintStat();
    }
}
