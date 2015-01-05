namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Multiply : Calculation
    {
        private int result;
        public Multiply(int val, Calculation calc)
        {
            result = val * calc.GetResult();

        }
        public Multiply(Calculation calc, int val)
        {
            result = calc.GetResult() * val;
        }

        public Multiply(Calculation calc1, Calculation calc2)
        {
            result = calc1.GetResult() * calc2.GetResult();
        }
        public Multiply(int val1, int val2)
        {
            result = val1 * val2;
        }
        public override int GetResult()
        {
            return result;
        }
    }
}
