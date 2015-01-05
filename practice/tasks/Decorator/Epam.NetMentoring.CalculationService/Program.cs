using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.CalculationService
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculationService nonCachedService = new CalculationService();
            ICalculationService cachedService = new CachedCalculationService(nonCachedService);
            cachedService.Calculate(10, 10);
           
        }
    }
}
