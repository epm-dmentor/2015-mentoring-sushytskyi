namespace Epam.NetMentoring.Factory
{
    public class BankFactory : IBankFactory
    {
        public IBank CreateBank(string name)
        {
            IBank bank = null;
            switch (name)
            {
                case "Barcap":
                    bank = new Barcap("Barcap");
                    break;
                case "Connacord":
                    bank = new Connacord("Connacord");
                    break;
                case "BOFA":
                    bank = new Bofa("BOFA");
                    break;
            }
            return bank;
        }

    }
}
