using System;


namespace Epam.NetMentoring.StockExchange
{
    //IT2: if i hadn't added comment to this fine about unused namespaces, it does not mean that you should not remove it
    //IT2: I though the one comment for the project is enought to remove unused namspaces from the all files
    //IS2: Sorry, i realy missed this file 
    class Program
    {
        static void Main(string[] args)
        {

            IStockExchange stockExchange=new StockExchange();            
            IStockExchangeListener loger = new ExchangeLogger();

            stockExchange.Sold += loger.OnSold;
            stockExchange.SellingRequested += loger.OnRequestSelling;        

            IBroker broker1 = new Broker("Broker1");
            IBroker broker2 = new Broker("Broker2");

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
