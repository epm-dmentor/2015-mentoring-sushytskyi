namespace Epam.NetMentoring.Factory.UVAR
{
    internal interface IFeedManagerFactory
    {
        IFeedManager GetFeedManger(TradeFeed feed);
    }
}