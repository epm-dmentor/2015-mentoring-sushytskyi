using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
   public interface IObservable<T>
   {
       void Subscribe(T observer);
       void Unsubscribe(T observer);
       void NotifyObserver();
   }
}
