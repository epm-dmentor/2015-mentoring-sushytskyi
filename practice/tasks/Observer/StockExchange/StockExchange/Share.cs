namespace Epam.NetMentoring.StockExchange
{
    public class Share
    {
        public string SecurityId { get; private set; }
        public int Ammount { get; private set; }
        public decimal Price { get; private set; }

        //IT: do you need it?
        //IS: removed

        public Share(string securityId, int ammount, decimal price)
        {
            this.SecurityId = securityId;
            this.Ammount = ammount;
            this.Price = price;
        }
    }
}
