using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
   public interface IBroker<T>
    {
        T Market { get; set; }
       IInformer Informer { get; set; }
       void Unsubscribe();

    }
}
