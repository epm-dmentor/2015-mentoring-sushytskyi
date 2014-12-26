namespace Epam.NetMentoring.Observer.Store.Interfaces
{
    //IT: internal interface?!
    interface ICustomer
    {
        string Name { get; }
        Item Buy(string itemName, int amount);
        void RegisterStore(IStore store);
        void UnRegisterStore();

        //IT: breaks IS principle from SOLID
        //IT: item added, why do you need oldAmount. Must it be zero for a new item?
        //IT: event added meand added! you can notify using that method about updating!
        void OnShopItemAdded(ProductInfo info,int oldAmount);
    }
}
