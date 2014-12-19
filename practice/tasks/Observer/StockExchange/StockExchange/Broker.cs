using System;

namespace Epam.NetMentoring.StockExchange
{
   public class Broker:IBroker
    {
        public string BrokerName { get; set; }
        public IStockExchange StockExchange;

       public Broker(IStockExchange exchange,string brokerName)
        {
            this.BrokerName = brokerName;
           this.StockExchange = exchange;
        }

        public void Buy(string securityId, int price, int amount)
        {
            StockExchange.Buy(this, securityId, amount, price);
        }

        public void Sell(string securityId, int price, int amount)
        {
            StockExchange.RequestSell(this, securityId, amount, price);
        }

        public void OnSold(DealInfo info)
        {
            throw new NotImplementedException();
        }

        public void OnRequestSelling(SellRequest info)
        {
            throw new NotImplementedException();
        }
    }
}
