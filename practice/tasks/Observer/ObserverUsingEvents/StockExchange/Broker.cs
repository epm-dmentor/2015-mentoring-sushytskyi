using System;

namespace ConsoleApplication5
{
    public class Broker
    {
        public string BrokerName { get; set; }
        public StockExchange Market { get; set; }
        public IInformer<Broker> Informer { get; set; }

        public Broker(string brokerName, IInformer<Broker> informer)
        {
            BrokerName = brokerName;
            Informer = informer;
        }

        public void Update(object sender)
        {
            Market = (StockExchange)sender;
        
            Informer.PrintStat(this);
        }

        public void Sell(string secCode, decimal price, int amount)
        {
            Market.RegisterSell(secCode, price, amount, this);

        }
        public void Buy(string secCode, decimal price, int amount)
        {
            Market.RegisterBuy(secCode, price, amount, this);
        }


        public override string ToString()
        {
            return this.BrokerName;
        }
    }
}
