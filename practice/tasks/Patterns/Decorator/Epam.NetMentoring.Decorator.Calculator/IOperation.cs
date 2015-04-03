namespace Epam.NetMentoring.Decorator.Calculator
{
    public interface IOperation
    {
        //IT: Result from divide/multiply is not always int
        //IS: good point but want to discuss it before changing 
        double GetResult();
    }
}
