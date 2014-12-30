namespace Epam.NetMentoring.Observer.Store
{

    //IT: you have it in interfaces. It can't be internal!!!!!!!
    public class Item
    {
        public Item(string name, int amount, decimal price)
        {
            //IT: what does this comment mean?!
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
        }
        public string Name { get; private set; }
        public int Amount { get; private set; }
        public decimal Price { get; private set; }

    }
}
