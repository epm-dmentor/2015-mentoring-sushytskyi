using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
    public partial class StockExchange
    {
        private class ExchangeInternalAccounts
        {
            //IT2: you must not use public fields event in internal class. Encapsulation,Encapsulation and one more time - Encapsulation!
            //IS2: I need this class to have public setters to manipulate with accounts but I made stock exchange as partial class
            //IS2:and made this class as private so its not visible externally. 
            public decimal CashBalance { get; set; }
            public IList<Share> Shares { get; set; }
            public IBroker Broker { get; set; }

            public ExchangeInternalAccounts(IList<Share> list, int cashBalance, IBroker broker)
            {
                // TODO: Complete member initialization
                this.Shares = list;
                this.CashBalance = cashBalance;
                this.Broker = broker;
            }
        }
    }
}
