using Epam.NetMentoring.Observer.Store.Interfaces;
namespace Epam.NetMentoring.Observer.Store
{
  public  interface ISupplier:IStoreSubscriber
    {
        IStore DeliveryStore { get; set; }
        string Name { get; }
    }
}
