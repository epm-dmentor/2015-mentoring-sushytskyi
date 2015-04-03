namespace Epam.NetMentoring.Observer.Store
{
    //IT: you have it in the interface
    public class ProductInfo
    {
        public string Name { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }

        public ProductInfo(string name, int amount, decimal price)
        {
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
        }
    }
}
