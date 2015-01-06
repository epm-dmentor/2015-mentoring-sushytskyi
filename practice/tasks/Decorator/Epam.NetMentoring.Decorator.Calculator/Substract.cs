namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Substract : IOperation
    {
        //IT: readonly
        private readonly IOperation _op1;
        private readonly IOperation _op2;

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
