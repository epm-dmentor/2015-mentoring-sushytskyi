namespace Epam.NetMentoring.Factory.UVAR
{
    public class EmFeedProcessor : FeedProcessor
    {
        protected override IFeedManager Manager
        {
            get { return new EmFeedManager(); }
        }
    }
}
