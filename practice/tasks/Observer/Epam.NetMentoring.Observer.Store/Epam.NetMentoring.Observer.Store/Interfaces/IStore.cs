namespace Epam.NetMentoring.Observer.Store.Interfaces
{
    public interface IStore : IStorePublisher
    {
        //IT: IT's better to move registering for events in different interface to not break SOLID
        //IT: as you use it for notification it's clearer to use method with name subscribe

        //IT: for identification of products, its better to use EAN, ID
        //    void AddProduct(string name, int amount, decimal price);
        //IT: the same, you can identify a product only by unique identifier
        Item Buy(string itemName, int amount);
        //IT: How can I get the list of all products?
        void SupplyItem(Item item);
    }
}
