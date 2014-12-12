namespace ConsoleApplication5
{
    public class Broker:IBroker<Market>
    {
        public string BrokerName { get; set; }
        public Market Market { get; set; }
        public IInformer Informer { get; set; }

        public Broker(string brokerName)
        {
            BrokerName = brokerName;
        }

        public void Sell(string secCode, decimal price, int amount)
        {
            Market.RegisterSell(secCode,price,amount,this);
        }
        public void Buy(string secCode, decimal price, int amount)
        {
            Market.RegisterBuy(secCode, price, amount, this);
        }

        public void GetUpdate(Informer notification)
        {
            Informer = notification;
        }

        public void Unsubscribe()
        {
            Market.Unsubscribe(this);
            Market = null;
        }

        public override string ToString()
        {
            return this.BrokerName;
        }
    }
}
