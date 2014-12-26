
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
                //IT2: it's not good approach to have dummy broker
                //IS2: dummy broker deleted null broker should be handled explicitly further 
                return _buyer;
            }
            private set
            {
                _buyer = value;
            }
        }


        public DealInfo(
            string securityId, 
            decimal price,
            int ammount, 
            IBroker buyer, 
            IBroker seller = null)
        {
            SecurityId = securityId;
            Price = price;
            Ammount = ammount;
            Buyer = buyer;
            Seller = seller;
        }
       

    }
}
