using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
    class ExchangeInternalAccounts
    {
        //IT2: you must not use public fields event in internal class. Encapsulation,Encapsulation and one more time - Encapsulation!
        public decimal CashBalance;
        public IList<Share> Shares;
        public IBroker Broker;

        public ExchangeInternalAccounts(IList<Share> list, int cashBalance, IBroker broker)
        {
            // TODO: Complete member initialization
            this.Shares = list;
            this.CashBalance = cashBalance;
            this.Broker = broker;
        }
    }
}
