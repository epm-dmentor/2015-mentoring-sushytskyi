using System.Dynamic;

namespace Epam.NetMentoring.StockExchange
{
    //IT: the same effect as you turn on camare and make a record in the mirror (a mirror in the mirror in the mirror...)
    //IT: It's bad idea to make class that just saves another object (at least at this case)
    public class DealInfo
    {
        private IBroker _seller;
        private IBroker _buyer;
        public string SecurityId { get; private set; }
        public int Ammount { get; private set; }
        public decimal Price { get; private set; }

        public IBroker Seller
        {
            get
            {
                //if no broker create dummy one with name "no broker" 
                if (_seller == null)
                    return new Broker("No broker");
                return _seller;
            }
            private set
            {
                _seller = value;
            }
        }

        public IBroker Buyer
        {
            get
            {
                //if no broker create dummy one with name "no broker" 
                //IT2: it's not good approach to have dummy broker
                if (_buyer == null)
                    return new Broker("No broker");
                return _buyer;
            }
            private set
            {
                _buyer = value;
            }
        }

        public DealInfo(string securityId, decimal price, int ammount, IBroker buyer)
        {
            // TODO: Complete member initialization
            this.SecurityId = securityId;
            this.Price = price;
            this.Ammount = ammount;
            this.Buyer = buyer;
        }

        public DealInfo(string securityId, decimal price, int ammount, IBroker buyer, IBroker seller)
        {
            // TODO: Complete member initialization
            this.SecurityId = securityId;
            this.Price = price;
            this.Ammount = ammount;
            this.Buyer = buyer;
            this.Seller = seller;
        }
        public DealInfo(IBroker seller, string securityId, decimal price, int ammount)
        {
            // TODO: Complete member initialization
            this.SecurityId = securityId;
            this.Price = price;
            this.Ammount = ammount;
            this.Seller = seller;
        }

    }
}
