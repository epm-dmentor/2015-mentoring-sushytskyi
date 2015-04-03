namespace Epam.NetMentoring.Observer.Store.Interfaces
{
    public interface IStoreSubscriber
    {
        void OnShopItemAdded(ProductInfo info);
        void OnLowItemCount(ProductInfo info);
    }
}
