using Epam.NetMentoring.Observer.Store.Interfaces;
using System;

namespace Epam.NetMentoring.Observer.Store
{
    public class Suplyer : ISuplyer
    {
        private const int _defaultSupplyCount = 5;
        private const int _supplyThreshold = 3;
        private IStorePublisher _storePublisher;
        private IStore _deliveryStore;
        public string Name { get; private set; }

        public Suplyer(string name)
        {
            this.Name = name;
        }
        public IStore DeliveryStore 
        { 
            get { return _deliveryStore; } 
            set 
            {
                _deliveryStore = value;
            } 
        }

        public void Subscribe(IStorePublisher publisher)
        {
            if (_storePublisher != null)
                throw new ApplicationException("already subcribed");
            _storePublisher = publisher;
        }

        public void UnSubscribe()
        {
            _storePublisher = null;
        }

        public void OnShopItemAdded(ProductInfo info)
        {
            Console.WriteLine("For Suplier, new item added  ", info.Name);
        }
        public void OnLowItemCount(ProductInfo info)
        {
            int suplyCount = _defaultSupplyCount + info.Amount;
            DeliveryStore.SuplyItem(new Item(info.Name, suplyCount, info.Price));
        }

    }
}
