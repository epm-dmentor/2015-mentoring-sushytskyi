namespace Epam.NetMentoring.StockExchange
{
    public interface IBroker : IStockExchangeListener
    {
        string Name { get; }
        BrokerAccount Account { get; }

        //Ok, SecurityNotFound, WrongPrice, NotEnoughSec,NotEnoughMoney
        ResultCode Buy(string securityId, int price, int amount);
        bool RequestSell(string securityId, int price, int amount);

        bool CancelRequest();

        void SettleStockExchange(IStockExchange exchange);
    }
}
