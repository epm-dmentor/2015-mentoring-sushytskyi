namespace Epam.NetMentoring.RetailEquity
{
    public interface IBankFactory
    {
        IBank CreateBank(string name);
    }
}