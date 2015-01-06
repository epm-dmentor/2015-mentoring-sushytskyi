namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Add : IOperation
    {
        //IT: Readonly - it's assigned only in the coustructor
        private IOperation _op1;
        private IOperation _op2;

        public Add(IOperation op1, IOperation op2)
        {
            _op1 = op1;
            _op2 = op2;
        }
        public  int GetResult()
        {
            return _op1.GetResult() + _op2.GetResult();
        }
    }
}
