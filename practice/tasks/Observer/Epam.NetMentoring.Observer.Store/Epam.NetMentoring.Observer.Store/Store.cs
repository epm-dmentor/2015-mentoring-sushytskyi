using System;
using System.Collections.Generic;
using System.Linq;
using Epam.NetMentoring.Observer.Store.Interfaces;

namespace Epam.NetMentoring.Observer.Store
{

    //IT:
    //есть концептуальные ошибки с GetNewStoreItem
    //давай сделаем так, я изменю слегка задание, чтобы ты пришел к правильному решинею
    //есть магазин, товары могут заканчиваться. Т.е. магазин трекает товары
    //но есть МЕГА поставщик, он контролирует стор и пополняет когда считает что магазину нужно пополнение существующих товаров (придумай какуюто логику)
    //для упрощения: магазин всегда принимает товар. Поставка товара бестплатна, так что денги тулить сюда не нужно
    //ВНИМАНИЕ: кода должно быть не много, изменений тоже. Если есть вопросы/сомнения лучше спросить по почте сначала, чтоб не колбасить код впустую 


    //IT: do you really want it to be internal?
    public class Store : IStore
    {

        private readonly IList<IStoreSubscriber> _customerList = new List<IStoreSubscriber>();
        private readonly IList<Item> _storeItems = new List<Item>();
        private const int _amountThreshold = 3;

        public bool Subscribe(IStoreSubscriber customer)
        {
            if (!_customerList.Contains(customer))
            {
                customer.Subscribe(this);
                _customerList.Add(customer);
                return true;
            }
            return false;
        }
        public void UnSubscribe(IStoreSubscriber customer)
        {
            var registredCustomer = _customerList.FirstOrDefault(s => s == customer);
            if (registredCustomer != null)
            {
                _customerList.Remove(registredCustomer);
                registredCustomer.UnSubscribe();
            }
        }
        public void SuplyItem(Item item)
        {
            var existItem = FindItem(_storeItems, item.Name);
            Item newItem;

            if (existItem != null)
            {
                _storeItems.Remove(existItem);
                newItem = GetUpdatedItem(existItem, item.Amount, item.Price);
                _storeItems.Add(newItem);

                //notify
                ItemAdded(newItem);
                return;
            }
            _storeItems.Add(item);

            //notify
            ItemAdded(item);
        }
        public Item Buy(string name, int amount)
        {
            var item = FindItem(_storeItems, name);

            if (item == null)
                return null;

            _storeItems.Remove(item);
            //update lsit of items new lower count
            var updatedItem = GetUpdatedItem(item, (amount * -1), item.Price);

            if (updatedItem == null)
                LowItemAmount(item);
            _storeItems.Add(updatedItem);

            //return new product item to user
            return new Item(name, amount, item.Price);
        }
        private Item FindItem(IEnumerable<Item> items, string name)
        {
            var item = items.FirstOrDefault(s => String.Equals(s.Name, name));
            return item;
        }

        private Item GetUpdatedItem(Item item, int amount, decimal price)
        {
            if (item == null)
                return null;
            var newItem = new Item(item.Name, (amount += item.Amount), price);
            if (newItem.Amount <= _amountThreshold)
            {
                return null;
            }
            return newItem;
        }
        private void ItemAdded(Item newItem)
        {
            var info = new ProductInfo(newItem.Name, newItem.Amount, newItem.Price);
            foreach (IStoreSubscriber customer in _customerList)
            {
                //IT: let's imagine we have 2 000 000, for the only one event this code will create 2 000 000 objects! 
                customer.OnShopItemAdded(info);
            }
        }

        private void LowItemAmount(Item item)
        {
            var productInfo = new ProductInfo(item.Name, item.Amount, item.Price);
            foreach (var customer in _customerList)
            {
                customer.OnLowItemCount(productInfo);
            }
        }

    }
}
