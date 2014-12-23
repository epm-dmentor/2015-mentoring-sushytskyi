using System;

namespace Epam.NetMentoring.StockExchange
{
    //IT: Ctrl + E + D for each file!!!!!
   public class Broker:IBroker
   {
        public string Name { get; private set; }
        public BrokerAccount Account {
            get
            {
                return StockExchange.GetAccount(this);
            }
            //IT: What do you mean by that?
            private set{} }

       //IT: public field?!
        public IStockExchange StockExchange;


       //IT: public field with get and set? What is the reason?
       public Guid SellrequestId { get; set; }

       public Broker(IStockExchange exchange,string brokerName)
        {
            this.Name = brokerName;

           //IT: it's better to use either constructor injection/property/metod, but not alltogether
           this.StockExchange = exchange;
        }

       public void OnSold(DealInfo info)
       {
           throw new NotImplementedException();
       }

       public void OnRequestSelling(SellRequest info)
       {
           throw new NotImplementedException();
       }

       
       public ResultCode Buy(string securityId, int price, int amount)
       {
           return StockExchange.Buy(this, securityId, amount, price);
       }

       public void RequestSell(string securityId, int price, int amount)
       {
          SellrequestId= StockExchange.RequestSell(this, securityId, amount, price);
       }

       public bool CancelRequest(Guid requestId)
       {
           //IT: What happnes if I run that method twice?
           return StockExchange.CancelRequest(requestId);
       }

       public void SettleStockExchange(IStockExchange exchange)
       {
           //IT: it's better to use either constructor injection/property/metod, but not alltogether
           //if the method is declared in the interface it's better to use the method to inject stock exchange
           StockExchange = exchange;
       }
    }
}
