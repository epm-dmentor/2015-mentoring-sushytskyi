using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.StockExchange
{
    class ExchangeInternalAccounts
    {
        public decimal CashBalance;
        public IEnumerable<Share> Shares;
        public IBroker Broker;

        public ExchangeInternalAccounts(IEnumerable<Share> list, int cashBalance, IBroker broker)
        {
            // TODO: Complete member initialization
            this.Shares = list;
            this.CashBalance = cashBalance;
            this.Broker = broker;
        }

   
    }
}
