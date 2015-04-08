using System;

namespace Epam.NetMentoring.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var adaptedPrinter = new AdaptedPrinter(new Container());
            adaptedPrinter.GetElements();
            Console.ReadLine();
        }
    }
}
