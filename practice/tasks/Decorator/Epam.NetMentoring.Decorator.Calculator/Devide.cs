namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Devide : IOperation
    {
        private IOperation _op1;
        private IOperation _op2;

        public Devide(IOperation op1, IOperation op2)
        {
            _op1 = op1;
            _op2 = op2;
        }
        public int GetResult()
        {
            return _op1.GetResult() / _op2.GetResult();
        }
    }
}
