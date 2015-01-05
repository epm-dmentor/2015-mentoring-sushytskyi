namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Const : IOperation
    {
        private int _val = 0;
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
