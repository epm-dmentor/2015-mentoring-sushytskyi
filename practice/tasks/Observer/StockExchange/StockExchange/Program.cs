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
            //StockExchangeEventsLogger  informer=new StockExchangeEventsLogger();
           // stockExchange.Sold+= informer.OnSold;
            IBroker broker1 = new Broker(stockExchange, "Broker1");
            IBroker broker2 = new Broker(stockExchange,"Broker2");

            stockExchange.Register(broker1);
            stockExchange.Register(broker2);
            stockExchange.Bid(new Share("mmm", 10, 10));
            stockExchange.Bid(new Share("ttt", 1, 1));

            broker2.RequestSell("mmm", 10, 10);
            broker1.Buy("mmm", 10, 10);
            broker1.RequestSell("mmm", 10, 10);
            broker2.Buy("mmm", 10, 10);
            broker1.RequestSell("ttt", 1, 1);
//            broker2.Buy( "ttt", 1, 1);

            //request selling
            Console.ReadLine();
        }
    }
}
