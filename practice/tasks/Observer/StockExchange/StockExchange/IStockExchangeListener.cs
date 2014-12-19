using System.Security.Permissions;

namespace Epam.NetMentoring.StockExchange
{
  public interface IStockExchangeListener
  {
      void OnSold(DealInfo info);
      void OnRequestSelling(SellRequest info);
      void OnBuyRequested(BuyRequest info);
      void OnNewSecurityAdded(NewSecurity info);
      void OnBrokerRegistred(BrokerInfo info);
      void OnBrokerUnRegistred(BrokerInfo info);
  }
}
