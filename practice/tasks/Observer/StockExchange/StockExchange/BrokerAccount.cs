using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.StockExchange
{
    public class BrokerAccount
    {
        private decimal _cashBalance;
        private IEnumerable<Share> _shares;
        private IBroker _broker;

        public decimal CashBalance
        {
            get
            {
                return _cashBalance;
            }
        }
        public IEnumerable<Share> Shares
        {
            get
            {
                return _shares;
            }
        }
        public IBroker Broker
        {
            get
            {
                return _broker;
            }
        }
        
        public BrokerAccount(IEnumerable<Share> shares, decimal cashBalance,IBroker broker)
        {
            this._shares = shares;
            this._cashBalance = cashBalance;
        }
    }
}
