using System;

namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Devide : IOperation
    {
        private readonly IOperation _op1;
        private readonly IOperation _op2;

        public Devide(IOperation op1, IOperation op2)
        {
            _op1 = op1;
            _op2 = op2;
        }
        public double GetResult()
        {
            double res = 0;
            //IT: Divde by zero exception
            try
            {
                res = _op1.GetResult() / _op2.GetResult();
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine(ex.Message);
            }
            return res;
        }
    }
}
