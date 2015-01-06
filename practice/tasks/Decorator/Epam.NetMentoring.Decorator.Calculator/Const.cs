namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Const : IOperation
    {
        //IT: Readonly - assigned only in constructor
        private int _val = 0; //IT: zero is already default value for int
        public Const(int val)
        {
            _val = val;
        }
        public int GetResult()
        {
            return _val;
        }
    }
}
