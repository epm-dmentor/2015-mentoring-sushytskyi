using System;
using Epam.NetMentoring.Observer.Store.Interfaces;

namespace Epam.NetMentoring.Observer.Store
{
    class Customer : ICustomer
    {
        private IStorePublisher _storePublisher;
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        public void Subscribe(IStorePublisher store)
        {
            if (_storePublisher != null)
            {
                throw new Exception("Store already registred, Unregister first");
            }
            _storePublisher = store;
        }

        public void UnSubscribe()
        {
            if (_storePublisher != null)
            {
                _storePublisher.UnSubscribe(this);
                _storePublisher = null;
            }
            else
            {
                throw new Exception("Customer is not registred");
            }
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
