using System;

namespace Epam.NetMentoring.Factory.UVAR
{
    class Program
    {
        static void Main(string[] args)
        {
            //Em feeds Processing
            var emFeedProcessor = new EmFeedProcessor();
            emFeedProcessor.Process(new EmTradeFeedItem(11, "sdfsddd", 5, 6, new DateTime(2051, 10, 10), 56, 234, 12, "ghjhklryt"));
            emFeedProcessor.Process(new EmTradeFeedItem(11, "sdfsddd", 5, 6, new DateTime(2051, 10, 10), 56, 0, 12,
                "ghjhklryt"));
            emFeedProcessor.Process(new EmTradeFeedItem(10, "sdfsd", 3, 4, new DateTime(2011, 10, 10), 20, 12, 34, "sdfsd"));
            
            //D1 Feeds Processing 

            var d1FeedProcessor = new Delata1FeedProcessor();
            d1FeedProcessor.Process(new Delta1TradeFeedItem(10, "sdfsd", 3, 4, new DateTime(2011, 10, 10), 20, 12, "vbvbb", "sdfsd"));
            d1FeedProcessor.Process(new Delta1TradeFeedItem(11, "sdfsddd", 5, 6, new DateTime(2051, 10, 10), 56, 234, "bbnb", "ghjhklryt"));


        }
    }
}
