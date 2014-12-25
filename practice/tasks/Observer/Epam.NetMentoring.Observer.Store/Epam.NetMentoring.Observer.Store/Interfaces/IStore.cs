namespace Epam.NetMentoring.Observer.Store.Interfaces
{
    interface IStore
    {
        bool Register(ICustomer custore);
        void Unregister(ICustomer customer);
        void AddProduct(string name, int amount, decimal price);
        Item Buy(string itemName, int amount);        
    }
}
