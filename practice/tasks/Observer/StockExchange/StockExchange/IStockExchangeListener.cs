
namespace Epam.NetMentoring.StockExchange
{
  public interface IStockExchangeListener
  {
      void OnSold(DealInfo info);
      void OnRequestSelling(SellRequest info);
  }
}
