using System;

namespace Epam.NetMentoring.Decorator.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = new Add(new Multiply(1,1),new Multiply(new Add(1,1), 10)).GetResult();
   //         res = new Devide(12,5).GetResult();
            Console.ReadLine();
        }
    }
}
