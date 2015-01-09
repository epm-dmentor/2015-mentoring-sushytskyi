namespace Epam.NetMentoring.RetailEquity
{
    public class BankFactory : IBankFactory
    {
        private readonly IPositionFilter _equityFilter;
        public BankFactory(IPositionFilter equityFilter)
        {
            _equityFilter = equityFilter;
        }

        public IBank CreateBank(string name)
        {
            IBank bank = null;
            switch (name)
            {
                case "Barcap":
                    bank = new Barcap(_equityFilter);
                    break;
                case "Connacord":
                    bank = new Connacord(_equityFilter);
                    break;
                case "BOFA":
                    bank = new Bofa(_equityFilter);
                    break;
            }
            return bank;
        }

    }
}
