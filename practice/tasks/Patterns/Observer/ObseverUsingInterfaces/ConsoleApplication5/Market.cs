using System;
using System.Collections.Generic;

namespace ConsoleApplication5
{
    public class Market : IObservable<Broker>
    {
        private List<IObserver> _brokers = new List<IObserver>();

        public List<Bid> BidList
        {
            get
            {
                return _bidList;
            }
        }

        public List<Ask> AskList
        {
            get
            {
                return _askList;
            }
        }

        private List<Bid> _bidList = new List<Bid>();
        private List<Ask> _askList = new List<Ask>();

        public void Unsubscribe(Broker broker)
        {
            if (!_brokers.Exists(s => s == broker))
                return;

            _brokers.Remove(broker);
            broker.Market = null;
        }

        private void AcquireTrades()
        {
            foreach (Bid bid in _bidList)
            {
                foreach (Ask ask in _askList)
                {
                    if (bid.ackquireTranId == Guid.Empty)
                        if (bid.SecCode == ask.SecCode && ask.Amount == bid.Amount && bid.Price <= ask.Price &&
                            ask.ackquireTranId == Guid.Empty)
                        {
                            var tranId = Guid.NewGuid();

                            ask.ackquireTranId = tranId;
                            bid.ackquireTranId = tranId;
                        }
                }
            }
        }

        public void RegisterSell(string secCode, decimal price, int amount, Broker broker)
        {
            _bidList.Add(new Bid(secCode, price, amount, broker));
            AcquireTrades();
            NotifyObserver();

        }
        public void RegisterBuy(string secCode, decimal price, int amount, Broker broker)
        {
            _askList.Add(new Ask(secCode, price, amount, broker));
            AcquireTrades();
            NotifyObserver();

        }

        public void NotifyObserver()
        {
            foreach (Broker broker in _brokers)
            {
                broker.Update();
            }

        }

        public void Subscribe(Broker broker)
        {
            if (_brokers.Exists(s => s == broker))
                return;

            _brokers.Add(broker);
            broker.Market = this;
            NotifyObserver();
        }
    }
}
