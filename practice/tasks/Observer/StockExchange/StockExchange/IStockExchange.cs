namespace Epam.NetMentoring.StockExchange
{
    public interface IStockExchange
    {
        event SoldEventHandler Sold;
        event SellingRequestedHandler SellingRequested;

        void Buy(IBroker broker,string securityId, int ammount, int price);
        void RequestSell(IBroker broker,string securityId, int ammount, int price);

        void Register(IBroker broker);
    }
}
