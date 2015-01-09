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
        //IS: For double type there is no devision by 0 exception, 
        //IS:The best solution i found check result. 
        public double GetResult()
        {
            double res = 0;
            //IT: Divde by zero exception
            res = _op1.GetResult() / _op2.GetResult();
            if (double.IsInfinity(res) || double.IsNaN(res))
                throw new DivideByZeroException(String.Format("attempt to devide by zero {0},{1}", _op1.GetResult(),
                    _op2.GetResult()));
            return res;
        }
    }
}
