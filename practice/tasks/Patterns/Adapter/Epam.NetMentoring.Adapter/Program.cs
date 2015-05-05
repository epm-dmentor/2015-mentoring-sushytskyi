using System;
using System.Drawing;
using System.Reflection;

namespace Epam.NetMentoring.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();
            
            var elems = new ElementsContainer(new[] {(object)new Point(1, 1), new Point(2, 20), new Point(33, 23)});

            var adapter = new Adapter(printer, elems);
            adapter.Print();
      //      printer.Print(elems);
            Console.ReadLine();
        }
    }
}
