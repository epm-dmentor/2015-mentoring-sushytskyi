using System;
using System.Collections.Generic;

namespace ConsoleApplication5
{
    public class Market: IMarket<Broker>
    {
        private List<IBroker<Market>> _brokers { get; set; }
        private List<Bid> _bidList = new List<Bid>();
        private List<Ask> _aksList = new List<Ask>();

        public Market()
        {
            _brokers = new List<IBroker<Market>>();
        }

        public void Unsubscribe(Broker broker)
        {
            if (!_brokers.Exists(s => ((Broker)s).BrokerName == broker.BrokerName))

            _brokers.Remove(broker);

            broker.Informer = null;
            broker.Market = null;
        }

        private void AcquireTrades()
        {
            foreach (Bid bid in _bidList)
            {
                foreach (Ask ask in _aksList)
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
            NotifyBrokers();

        }
        public void RegisterBuy(string secCode, decimal price, int amount, Broker broker)
        {
            _aksList.Add(new Ask(secCode, price, amount, broker));
            AcquireTrades();
            NotifyBrokers();

        }
        public void NotifyBrokers()
        {
            foreach (Broker broker in _brokers)
            {
                var brokerAskList = _aksList.FindAll(s =>s.ackquireTranId == Guid.Empty);
                var brokerBidList = _bidList.FindAll(s =>s.ackquireTranId == Guid.Empty);
                var soldList = _bidList.FindAll(s => s.Broker == broker && s.ackquireTranId != Guid.Empty);
                var buysConfirmedlist = _aksList.FindAll(s => s.Broker == broker && s.ackquireTranId != Guid.Empty);

                broker.GetUpdate(new Informer(brokerAskList, brokerBidList,buysConfirmedlist, soldList));
            }
        }

        
        public void Subscribe(Broker broker)
        {
            if (!_brokers.Exists(s => ((Broker)s).BrokerName == broker.BrokerName))
                _brokers.Add(broker);

            broker.Market = this;
            NotifyBrokers();
        }
    }
}
