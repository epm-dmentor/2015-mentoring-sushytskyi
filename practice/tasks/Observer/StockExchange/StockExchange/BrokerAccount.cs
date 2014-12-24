using System.Collections.Generic;
//IT: unused namspaces?!

namespace Epam.NetMentoring.StockExchange
{
    public class BrokerAccount
    {
        //Readonly?
        private readonly decimal _cashBalance;
        private readonly IEnumerable<Share> _shares;

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

        //IT: you have broker in the param list, but do not use it
        public BrokerAccount(IEnumerable<Share> shares, decimal cashBalance)
        {
            this._shares = shares;
            this._cashBalance = cashBalance;
        }
    }
}
