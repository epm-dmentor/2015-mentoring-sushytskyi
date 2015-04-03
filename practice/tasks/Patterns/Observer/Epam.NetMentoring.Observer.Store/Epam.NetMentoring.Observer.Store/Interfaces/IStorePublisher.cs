namespace Epam.NetMentoring.Observer.Store.Interfaces
{
    public interface IStorePublisher
    {
        bool Subscribe(IStoreSubscriber customer);
        //IT: unsubscribe
        void UnSubscribe(IStoreSubscriber customer);

    }
}
