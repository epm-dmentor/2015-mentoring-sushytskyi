﻿using System;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            var market = new Market();
            var informer = new Informer(market);

            var broker1 = new Broker("Broker1", informer);
            market.Subscribe(broker1);

            var broker2 = new Broker("Broker2", informer);
            market.Subscribe(broker2);

            broker1.Buy("MSFT",10,10);
            broker1.Buy("TST",10.5m,10);

            broker2.Sell("MSFT",10,20);
            broker2.Sell("MSFT", 10, 10);
            //broker2.Sell("NDT", 10, 10);
            market.Unsubscribe(broker1);

            //broker2.Sell("TST", 10.5m, 10);
            //broker2.Unsubscribe();
            //market.Subscribe(broker2);
            //informer.PrintStat(broker2);


            Console.ReadLine();
        }
    }
}
