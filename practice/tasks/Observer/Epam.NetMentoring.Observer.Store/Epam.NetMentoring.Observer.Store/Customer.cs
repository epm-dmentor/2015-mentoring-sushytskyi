using System;
using Epam.NetMentoring.Observer.Store.Interfaces;

namespace Epam.NetMentoring.Observer.Store
{
    class Customer : ICustomer
    {
        private IStore _store;
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        public void RegisterStore(IStore store)
        {
            if (_store != null)
            {
                throw new Exception("Store already registred, Unregister first");
            }
                _store = store;
        }

        public void UnRegisterStore()
        {
            if (_store != null)
            {
                _store.Unregister(this);
                _store = null;
            }
            else
            {
                throw new Exception("Customer is not registred");
            }
        }

        public Item Buy(string itemName, int amount)
        {
            return _store.Buy(itemName, amount);

        }
        public void OnShopItemAdded(ProductInfo info, int oldAmount)
        {
            Console.WriteLine("Notifcation for {0}: New item in Store: Name-> {1} |New Amount-> {2} |Old Amount-> {3}|Price-> {4} ", this.Name, info.Name, info.Amount, oldAmount, info.Price);
        }
    }
}
