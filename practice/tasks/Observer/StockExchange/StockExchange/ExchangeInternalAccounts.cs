using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
    class ExchangeInternalAccounts
    {
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
