namespace ConsoleApplication5
{
    public class Broker:IObserver
    {
        public string BrokerName { get; set; }
        public Market Market { get; set; }
        public IInformer<Broker> Informer { get; set; }

        public Broker(string brokerName, IInformer<Broker> informer)
        {
            BrokerName = brokerName;
            Informer = informer;
        }

        public void Update()
        {
            Informer.PrintStat(this);
        }

        public void Sell(string secCode, decimal price, int amount)
        {
            Market.RegisterSell(secCode,price,amount,this);
        }
        public void Buy(string secCode, decimal price, int amount)
        {
            Market.RegisterBuy(secCode, price, amount, this);
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
