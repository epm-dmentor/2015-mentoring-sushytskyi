namespace Epam.NetMentoring.RetailEquity
{
    public class Position
    {
        public string Type { get; private set; }
        public int Amount { get; private set; }
        public string SubType { get; private set; }

        public Position(string type, int amount, string subType)
        {
            Type = type;
            Amount = amount;
            SubType = subType;
        }
    }
}
