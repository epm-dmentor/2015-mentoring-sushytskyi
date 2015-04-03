namespace Epam.NetMentoring.Factory.UVAR
{
    public class Delata1FeedProcessor : FeedProcessor
    {
        protected override IFeedManager Manager
        {
            get { return new Delta1FeedManager(); }
        }

    }
}
