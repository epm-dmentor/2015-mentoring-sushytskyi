namespace Epam.NetMentoring.Observer.Store
{
    class ProductInfo
    {
        public string Name { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }

        public ProductInfo(string name, int amount, decimal price)
        {
            // TODO: Complete member initialization
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
        }
    }
}
