using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
   public interface IBroker:IStockExchangeListener
   {
       IEnumerable<ActiveBuy> GetActiveBuys();
       IEnumerable<ActiveSell> GetActiveSells();
       IDictionary<string, int> GetMySecurityPosition();
       decimal GetMyCashPosition();
       void Buy(string securityId, int price, int amount);
       void Sell(string securityId, int price, int amount);
   }
}
