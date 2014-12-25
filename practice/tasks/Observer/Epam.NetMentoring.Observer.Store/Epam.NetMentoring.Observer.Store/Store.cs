using System;
using System.Collections.Generic;
using System.Linq;
using Epam.NetMentoring.Observer.Store.Interfaces;

namespace Epam.NetMentoring.Observer.Store
{
    class Store : IStore
    {
        private readonly IList<ICustomer> _customerList = new List<ICustomer>();
        private readonly IList<Item> _storeItems = new List<Item>();

        public bool Register(ICustomer customer)
        {
            if (!_customerList.Contains(customer))
            {
                customer.RegisterStore(this);
                _customerList.Add(customer);
                return true;
            }
            return false;
        }

        public void AddProduct(string name, int amount, decimal price)
        {
            var item = _storeItems.FirstOrDefault(s => s.Name == name);
            Item newItem;

            if (item != null)
            {
                _storeItems.Remove(item);
                newItem = GetNewStoreItem(item, true, amount, price, null);
                _storeItems.Add(newItem);
                
                //notify
                ProductAdded(newItem, item.Amount);
            }
            else
            {
                newItem = GetNewStoreItem(null, true, amount, price, name);
                _storeItems.Add(newItem);
                
                //notify
                ProductAdded(newItem);
            }

        }

        private Item GetNewStoreItem(Item oldItem, bool increase, int amount, decimal price, string name)
        {
            if (oldItem != null && increase)
            {
                return new Item(oldItem.Name, oldItem.Amount + amount, price);
            }
            if (oldItem != null && !increase)
            {
                return new Item(oldItem.Name, oldItem.Amount - amount, price);
            }
            if (oldItem == null && increase)
            {
                return new Item(name, amount, price);
            }

            if (oldItem == null && !increase)
            {
                throw new Exception("Nothing to decrease");
            }
            return null;
        }

        public Item Buy(string name, int amount)
        {
            var item = _storeItems.FirstOrDefault(s => s.Name == name);
           
            //incorrect item to buy
            if (item == null)
                return null;
            
            _storeItems.Remove(item);
            //update lsit of items new lower count
            _storeItems.Add(GetNewStoreItem(item, false, amount, item.Price, null));

            //return new product item to user
            return GetNewStoreItem(null, true, amount, item.Price, item.Name);
        }

        /// <summary>
        /// Notification method
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="oldAmount"></param>
        private void ProductAdded(Item newItem, int oldAmount = 0)
        {
            foreach (ICustomer customer in _customerList)
            {
                customer.OnShopItemAdded(new ProductInfo(newItem.Name, newItem.Amount, newItem.Price), oldAmount);
            }
        }


        public void Unregister(ICustomer customer)
        {
            var registredCustomer = _customerList.FirstOrDefault(s => s.Name == customer.Name);
            if (registredCustomer != null)
            {
                _customerList.Remove(registredCustomer);
                registredCustomer.UnRegisterStore();
            }
        }
    }
}
