namespace Epam.NetMentoring.RetailEquity
{
    public interface IPositionFilterFactory
    {
        IPositionFilter CreatePositionFilter(string name);
    }
}