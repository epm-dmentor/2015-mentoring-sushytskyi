namespace Epam.NetMentoring.Factory.UVAR
{
    class FeedManagerFactory : IFeedManagerFactory
    {
        public IFeedManager GetFeedManger(TradeFeed feed)
        {
            if (feed is EmTradeFeed)
                return new EmFeedManager((EmTradeFeed)feed);

            if (feed is D1TradeFeed)
                return new D1FeedManager((D1TradeFeed)feed);

            return null;
        }
    }
}
