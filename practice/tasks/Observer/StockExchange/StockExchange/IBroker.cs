﻿
namespace Epam.NetMentoring.StockExchange
{
   public interface IBroker:IStockExchangeListener
   {    
       string Name { get; }
       BrokerAccount Account { get; }

       //Ok, SecurityNotFound, WrongPrice, NotEnoughSec
       ResultCode Buy(string securityId, int price, int amount);
       void RequestSell(string securityId, int price, int amount);

       bool CancelRequest(string requestId);
       void SettleStockExchange(IStockExchange exchange);
   }
}
