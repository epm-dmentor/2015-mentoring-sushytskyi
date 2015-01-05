using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.CalculationService
{
    public class CachedCalculationService : ICalculationService
    {
        private ICalculationService _calculationService;
        private decimal _calcRes;
        public Dictionary<int, decimal> Cache = new Dictionary<int, decimal>();
        public CachedCalculationService(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        public decimal Calculate(decimal a, decimal b)
        {
            _calcRes = _calculationService.Calculate(a, b);
            Cache.Add(Cache.Count, _calcRes);
            return _calcRes;
        }
    }
}
