namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Substract : IOperation
    {
        private IOperation _op1;
        private IOperation _op2;

        public Substract(IOperation op1, IOperation op2)
        {
            _op1 = op1;
            _op2 = op2;
        }
        public int GetResult()
        {
            return _op1.GetResult() - _op2.GetResult();
        }
    }
}
