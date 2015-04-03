using System;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            var market = new StockExchange();

            var informer = new Informer(market);

            var broker1 = new Broker("Broker1", informer);
            market.OnNotify +=broker1.Update;

            var broker2 = new Broker("Broker2", informer);
            market.OnNotify +=broker2.Update;

            broker1.Buy("MSFT",10,10);
            broker1.Buy("TST",10.5m,10);

            broker2.Sell("MSFT",10,20);
            broker2.Sell("MSFT", 10, 10);
            market.OnNotify -= broker1.Update;
            
            broker2.Sell("TST", 10.5m, 10);

            market.OnNotify -= broker2.Update;
            

            Console.ReadLine();
        }
    }
}
