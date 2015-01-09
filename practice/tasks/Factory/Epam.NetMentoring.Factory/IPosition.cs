namespace Epam.NetMentoring.Factory
{
    public interface IPosition
    {
        string Type { get; }
        int Amount { get; }
        string SubType { get; }
    }
}