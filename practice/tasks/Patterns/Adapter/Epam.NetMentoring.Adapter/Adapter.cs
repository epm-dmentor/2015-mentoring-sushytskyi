using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Adapter
{
   public class Adapter
    {
        private readonly Printer _printer;
        private readonly IElements<object> _elems;
        public Adapter(Printer printer, IElements<object> elems)
        {
            _printer = printer;
            _elems = elems;
        }

        public void Print()
        {
            _printer.Print(new Container(_elems.GetElements()));
        }

    }
}
