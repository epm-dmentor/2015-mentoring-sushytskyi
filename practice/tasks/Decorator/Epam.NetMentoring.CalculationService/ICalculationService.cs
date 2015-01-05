using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.CalculationService
{
   public interface ICalculationService
    {
       decimal Calculate(decimal a, decimal b);
    }
}
