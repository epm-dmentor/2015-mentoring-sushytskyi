namespace Epam.NetMentoring.Decorator.Calculator
{
    public class Devide : Calculation
    {
        private int result;
        public Devide(int val, Calculation calc)
        {
            result = val / calc.GetResult();

        }
        public Devide(Calculation calc, int val)
        {
            result = calc.GetResult() / val;
        }

        public Devide(Calculation calc1, Calculation calc2)
        {
            result = calc1.GetResult() / calc2.GetResult();
        }
        public Devide(int val1, int val2)
        {
            result = val1 / val2;
        }
        public override int GetResult()
        {
            return result;
        }
    }
}
