namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Add : Calculation
    {
        private int result;
        public Add(int val, Calculation calc)
        {
            result = val + calc.GetResult();

        }
        public Add(Calculation calc, int val)
        {
            result = calc.GetResult() + val;
        }

        public Add(Calculation calc1, Calculation calc2)
        {
            result = calc1.GetResult() + calc2.GetResult();
        }
        public Add(int val1, int val2)
        {
            result = val1 + val2;
        }
        public override int GetResult()
        {
            return result;
        }
    }
}
