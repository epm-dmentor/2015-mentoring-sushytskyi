using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
    public interface IStockExchange
    {
        event SoldEventHandler Sold;
        event SellingRequestedEventHandler SellingRequested;

        ResultCode Buy(IBroker broker, string securityId, int ammount, decimal price);
        Guid RequestSell(IBroker broker, string securityId, int ammount, decimal price);
        bool CancelRequest(Guid requestId);

        IStockExchange Register(IBroker broker); //1000 dollars
        void Bid(Share share);
        IEnumerable<Share> GetAvailableShares();
        BrokerAccount GetAccount(IBroker broker);
    }
}
