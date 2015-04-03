namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Const : IOperation
    {
        //IT: Readonly - assigned only in constructor
        private readonly int _val; //IT: zero is already default value for int
        public Const(int val)
        {
            _val = val;
        }
        public double GetResult()
        {
            return _val;
        }
    }
}
