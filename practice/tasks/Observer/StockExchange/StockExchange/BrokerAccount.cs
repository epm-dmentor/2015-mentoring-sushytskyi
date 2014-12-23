using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//IT: unused namspaces?!

namespace Epam.NetMentoring.StockExchange
{
    public class BrokerAccount
    {
        //Readonly?
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

        //IT: I asked to make it as readonly list
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
        
        //IT: you have broker in the param list, but do not use it
        public BrokerAccount(IEnumerable<Share> shares, decimal cashBalance,IBroker broker)
        {
            this._shares = shares;
            this._cashBalance = cashBalance;
        }
    }
}
