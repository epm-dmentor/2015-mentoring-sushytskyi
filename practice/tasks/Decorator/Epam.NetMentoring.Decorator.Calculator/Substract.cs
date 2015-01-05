namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Substract : Calculation
    {
        private int result;
        public Substract(int val, Calculation calc)
        {
            result = val - calc.GetResult();

        }
        public Substract(Calculation calc, int val)
        {
            result = calc.GetResult() - val;
        }

        public Substract(Calculation calc1, Calculation calc2)
        {
            result = calc1.GetResult() - calc2.GetResult();
        }
        public Substract(int val1, int val2)
        {
            result = val1 - val2;
        }
        public override int GetResult()
        {
            return result;
        }
    }
}
