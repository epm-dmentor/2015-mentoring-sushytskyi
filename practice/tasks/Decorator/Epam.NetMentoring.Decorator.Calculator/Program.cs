using System;

namespace Epam.NetMentoring.Decorator.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res = new Add(
            //    new Multiply(
            //        new Const(12),
            //        new Const(3)),
            //        new Add(
            //            new Const(2)
            //            , new Devide(
            //                new Const(12),
            //                new Const(3)))).GetResult();

            //Console.WriteLine("Calculation result is: {0} ", res);
            //Console.ReadLine();

            var res1 = new Devide(new Const(1), new Const(0)).GetResult();
            Console.ReadLine();
        }
    }
}
