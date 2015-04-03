using System;

namespace Epam.NetMentoring.Factory.UVAR
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Em feeds Processing
                var emFeedProcessor = new EmFeedProcessor();
                emFeedProcessor.Process(new EmTradeFeedItem()
                {
                    StagingId = 11,
                    SourceTradeRef = "sdfsddd",
                    CounterpartyId = 5,
                    PrincipalId = 6,
                    ValuationDate = new DateTime(2051, 10, 10),
                    CurrentPrice = 56,
                    SourceAccountId = 234,
                    BrokerId = 12,
                    Comments = "ghjhklryt"
                });
                emFeedProcessor.Process(new EmTradeFeedItem()
                {
                    StagingId = 11,
                    SourceTradeRef = "sdfsddd",
                    CounterpartyId = 5,
                    PrincipalId = 6,
                    ValuationDate = new DateTime(2051, 10, 10),
                    CurrentPrice = 56,
                    SourceAccountId = 0,
                    BrokerId = 12,
                    Comments = "ghjhklryt"
                });
                emFeedProcessor.Process(new EmTradeFeedItem()
                {
                    StagingId = 10,
                    SourceTradeRef = "sdfsd",
                    CounterpartyId = 3,
                    PrincipalId = 4,
                    ValuationDate = new DateTime(2011, 10, 10),
                    CurrentPrice = 20,
                    SourceAccountId = 12,
                    BrokerId = 34,
                    Comments = "sdfsd"
                });

                //D1 Feeds Processing 

                var d1FeedProcessor = new Delata1FeedProcessor();
                d1FeedProcessor.Process(new Delta1TradeFeedItem()
                {
                    StagingId = 10,
                    SourceTradeRef = "sdfsd",
                    CounterpartyId = 3,
                    PrincipalId = 4,
                    ValuationDate = new DateTime(2011, 10, 10),
                    CurrentPrice = 20,
                    SourceAccountId = 12,
                    SecurityId = "vbvbb",
                    Market = "sdfsd"
                });
                d1FeedProcessor.Process(new Delta1TradeFeedItem()
                {
                    StagingId = 11,
                    SourceTradeRef = "sdfsddd",
                    CounterpartyId = 5,
                    PrincipalId = 6,
                    ValuationDate = new DateTime(2051, 10, 10),
                    CurrentPrice = 56,
                    SourceAccountId = 10,
                    SecurityId = "bbnb",
                    Market = "ghjhklryt"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
