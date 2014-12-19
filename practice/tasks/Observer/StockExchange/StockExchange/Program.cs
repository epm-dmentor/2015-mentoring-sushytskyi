using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.StockExchange
{
    class Program
    {
        static void Main(string[] args)
        {

            IStockExchange stockExchange=new StockExchange();            
            Informer  informer=new Informer();
            stockExchange.Sold+= informer.OnSold;
            IBroker broker1 = new Broker(stockExchange, "Broker1");
            IBroker broker2 = new Broker(stockExchange,"Broker2");
            stockExchange.Register(broker1);
            stockExchange.Register(broker2);
            
            broker2.Sell("mmm", 10, 10);
            broker1.Buy("mmm", 10, 10);
            broker1.Sell("ttt", 1, 1);
//            broker2.Buy( "ttt", 1, 1);

            //request selling
            Console.ReadLine();
        }
    }
}
