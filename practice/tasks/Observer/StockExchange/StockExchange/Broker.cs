using System;

namespace Epam.NetMentoring.StockExchange
{
   public class Broker:IBroker
   {
        public string Name { get; private set; }
        public BrokerAccount Account {
            get
            {
                return StockExchange.GetAccount(this);
            }
            private set{} }
        public IStockExchange StockExchange;
       public Guid SellrequestId { get; set; }

       public Broker(IStockExchange exchange,string brokerName)
        {
            this.Name = brokerName;
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
           return StockExchange.CancelRequest(requestId);
       }

       public void SettleStockExchange(IStockExchange exchange)
       {
           StockExchange = exchange;
       }
    }
}
