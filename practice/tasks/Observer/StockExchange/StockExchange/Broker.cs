using System;

namespace Epam.NetMentoring.StockExchange
{
    //IT: Ctrl + E + D for each file!!!!!
    public class Broker : IBroker
    {
        public string Name { get; private set; }
        public BrokerAccount Account
        {
            get
            {
                return _stockExchange.GetAccount(this);
            }
            //IT: What do you mean by that?
            //  private set { }
        }

        //IT: public field?!
        private IStockExchange _stockExchange;


        //IT: public field with get and set? What is the reason?
        //  public Guid SellrequestId { get; set; }
        private Guid _sellRequestId;

        public Broker(string brokerName)
        {
            this.Name = brokerName;
            //IT: it's better to use either constructor injection/property/metod, but not alltogether
            // this.StockExchange = exchange;
        }

        public void OnSold(DealInfo info)
        {
            //IT2: React somehow to the event
            Console.WriteLine("New Deal: Security {0} | Ammount {1} | Price {2}| ",
                                info.SecurityId, info.Ammount, info.Price);
        }

        public void OnRequestSelling(DealInfo info)
        {
            Console.WriteLine("New sell requested: Security {0} | Ammount {1} | Price {2}| ",
                                info.SecurityId, info.Ammount, info.Price);

        }


        public ResultCode Buy(string securityId, int price, int amount)
        {
            return _stockExchange.Buy(this, securityId, amount, price);
        }

        //IT3: it's better to use bool
        public bool RequestSell(string securityId, int price, int amount)
        {
            if (_sellRequestId != Guid.Empty)
            {
                Console.WriteLine("You have already requested a sell, please cancel it first");
                return false;
            }
            _sellRequestId = _stockExchange.RequestSell(this, securityId, amount, price);
            if (_sellRequestId != Guid.Empty)
                return true;
            return false;
        }
        //
        public bool CancelRequest()
        {
            //IS: As per requirements only one buy request can be raised at the moment hence request id can be stored internaly and canceled upon request
            //IT2: in that case you MUST garantee to allow only one request.
            //IS2: Correct in RequestSell
            var resultCode = _stockExchange.CancelRequest(_sellRequestId);
            _sellRequestId = Guid.Empty;

            return resultCode;
        }


        public void SettleStockExchange(IStockExchange exchange)
        {
            if (_stockExchange != null)
                throw new ApplicationException("Already subscribed");

            //IT: it's better to use either constructor injection/property/metod, but not alltogether
            //if the method is declared in the interface it's better to use the method to inject stock exchange
            _stockExchange = exchange;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
