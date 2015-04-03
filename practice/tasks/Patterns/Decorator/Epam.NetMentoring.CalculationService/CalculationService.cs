using System.Threading;

namespace Epam.NetMentoring.CalculationService
{
  public class CalculationService:ICalculationService
    {
      public decimal Calculate(decimal a, decimal b)
      {
          Thread.Sleep(1000);
          return a * a + 2 * a * b * b * b;
      }
    }
}
