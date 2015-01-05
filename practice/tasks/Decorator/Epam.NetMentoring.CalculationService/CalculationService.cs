using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
