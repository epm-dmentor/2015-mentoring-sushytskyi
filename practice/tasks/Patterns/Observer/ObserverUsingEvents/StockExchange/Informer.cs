using System;
using System.Collections.Generic;

namespace ConsoleApplication5
{
    public class Informer : IInformer<Broker>
    {
        private StockExchange _market;

        public Informer(StockExchange market)
        {
            this._market = market;
        }

        public void PrintStat(Broker broker)
        {
            var brokerAskList = _market.AskList.FindAll(s => s.ackquireTranId == Guid.Empty);
            var brokerBidList = _market.BidList.FindAll(s => s.AckquireTranId == Guid.Empty);
            var soldList = _market.BidList.FindAll(s => s.Broker == broker && s.AckquireTranId != Guid.Empty);
            var buysConfirmedlist = _market.AskList.FindAll(s => s.Broker == broker && s.ackquireTranId != Guid.Empty);


            Console.WriteLine("Broker notification for Broker {0}",broker.BrokerName);
            brokerAskList.ForEach(s => Console.WriteLine("Open Ask Position|Security Code: {0}|Price: {1}|Amount: {2}|Broker: {3}", s.SecCode, s.Price, s.Amount, s.Broker));
            brokerBidList.ForEach(s => Console.WriteLine("Open Bid Position|Security Code: {0}|Price: {1}|Amount: {2}|Broker: {3}", s.SecCode, s.Price, s.Amount, s.Broker));
            soldList.ForEach(s => Console.WriteLine("Sold|Security Code: {0}|Price: {1}|Amount: {2}", s.SecCode, s.Price, s.Amount));
            buysConfirmedlist.ForEach(s => Console.WriteLine("Bought|Security Code: {0}|Price: {1}|Amount: {2}", s.SecCode, s.Price, s.Amount));
            Console.WriteLine("End of broker notification for Broker {0}",broker.BrokerName);
            Console.WriteLine("");
            Console.WriteLine("");
        }

    }
}
