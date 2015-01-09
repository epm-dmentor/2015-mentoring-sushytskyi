namespace Epam.NetMentoring.Factory
{
    public interface IBankFactory
    {
        IBank CreateBank(string name);
    }
}