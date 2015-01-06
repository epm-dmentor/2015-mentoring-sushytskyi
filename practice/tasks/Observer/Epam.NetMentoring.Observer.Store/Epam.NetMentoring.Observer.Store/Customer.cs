using Epam.NetMentoring.Observer.Store.Interfaces;
using System;

namespace Epam.NetMentoring.Observer.Store
{
    public class Customer : ICustomer
    {
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        public Item Buy(IStore store, string itemName, int amount)
        {
            if (store == null)
                throw new ApplicationException("no store supplied");
            return store.Buy(itemName, amount);
        }
        public void OnShopItemAdded(ProductInfo info)
        {
            Console.WriteLine("Notifcation for {0}: New offer : Name-> {1} | Amount-> {2}|Price-> {3} ", this.Name, info.Name, info.Amount, info.Price);
        }

        public void OnLowItemCount(ProductInfo info)
        {
            Console.WriteLine("hurey up, Only {0} {1} remained",info.Amount, info.Name);
        }
    }
}
