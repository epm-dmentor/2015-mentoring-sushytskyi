namespace Epam.NetMentoring.Observer.Store.Interfaces
{
    //IT: internal interface?!
    public interface ICustomer : IStoreSubscriber
    {
        string Name { get; }
        Item Buy(IStore store, string itemName, int amount);
        //IT: breaks IS principle from SOLID
        //IT: item added, why do you need oldAmount. Must it be zero for a new item?
        //IT: event added meand added! you can notify using that method about updating!

    }
}
