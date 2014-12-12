using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
   public interface IMarket<T>
   {
       void Subscribe(T broker);
       void RegisterSell(string secCode, decimal price, int amount, T broker);
       void RegisterBuy(string secCode, decimal price, int amount, T broker);
       void NotifyBrokers();
       void Unsubscribe(T broker);
   }
}
