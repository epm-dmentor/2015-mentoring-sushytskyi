using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    class Program
    {
        static void Main(string[] args)
        {
            var emFeed = new EmTradeFeed(
                new List<EmRecord>()
                {
                    new EmRecord(10, "sdfsd", 3, 4, new DateTime(2011, 10, 10), 20, 12, 34, "sdfsd"),
                    new EmRecord(11, "sdfsddd", 5, 6, new DateTime(2051, 10, 10), 56, 234, 12, "ghjhklryt"),
                    new EmRecord(11, "sdfsddd", 5, 6, new DateTime(2051, 10, 10), 56, 0, 12, "ghjhklryt")
                }
                );

            var d1feed = new D1TradeFeed(
               new List<D1Record>()
                {
                    new D1Record(10, "sdfsd", 3, 4, new DateTime(2011, 10, 10), 20, 12, "vbvbb", "sdfsd"),
                    new D1Record(11, "sdfsddd", 5, 6, new DateTime(2051, 10, 10), 56, 234, "bbnb", "ghjhklryt")
                }
                 );

            var processor = new FeedProcessor(new List<TradeFeed>() { emFeed, d1feed });
            processor.ProcessItems().ForEach(s => Console.WriteLine(s));

        }
    }
}
