namespace Epam.NetMentoring.Observer.Store.Interfaces
{
    public interface IStoreSubscriber
    {
        void Subscribe(IStorePublisher publisher);
        void UnSubscribe();

        void OnShopItemAdded(ProductInfo info);
        void OnLowItemCount(ProductInfo info);
    }
}
