using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
    public interface IStockExchange
    {
        void Buy(IBroker broker, string securityId, int ammount, decimal price);
        void RequestSell(IBroker broker, string securityId, int ammount, decimal price);
        IStockExchange Register(IBroker broker); //1000 dollars
        void AddSecurityListing(string securityId, int amount, decimal price);
        IEnumerable<ActiveSell> ShowActiveSells();
        IEnumerable<ActiveBuy> ShowActiveBuys();
        decimal ShowBrokerCashPostion(IBroker broker);
        IDictionary<string, int> ShowBrokerSecurityPosition(IBroker broker);

        event BrokerEventHandler BrokerRegistred;
        event BrokerEventHandler BrokerUnRegistred;
        event NewSecurityRegistredEventHandler NewSecurityRegistred;        
        event SoldEventHandler Sold;
        event SellingRequestedEventHandler SellingRequested;

        
    }
}
