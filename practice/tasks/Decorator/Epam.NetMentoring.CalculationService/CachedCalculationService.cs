using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.CalculationService
{
    public class CachedCalculationService : ICalculationService
    {
        private readonly ICalculationService _calculationService;
        private decimal _calcRes;
        private readonly Dictionary<int, decimal> _cache = new Dictionary<int, decimal>();
        public CachedCalculationService(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        public decimal Calculate(decimal a, decimal b)
        {
            var hashCode = a.GetHashCode() ^ b.GetHashCode();

            if (_cache.ContainsKey(hashCode))
            {
                Console.WriteLine("Cached value found");
                return _cache[hashCode];
            }

            _calcRes = _calculationService.Calculate(a, b);
            _cache.Add(hashCode, _calcRes);
            return _calcRes;
        }
    }
}
