namespace Epam.NetMentoring.Observer.Store.Interfaces
{
    interface ICustomer
    {
        string Name { get; }
        Item Buy(string itemName, int amount);
        void RegisterStore(IStore store);
        void UnRegisterStore();

        void OnShopItemAdded(ProductInfo info,int oldAmount);
    }
}
