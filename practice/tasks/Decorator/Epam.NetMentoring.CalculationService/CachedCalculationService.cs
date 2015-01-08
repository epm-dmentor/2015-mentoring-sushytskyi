using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.CalculationService
{
    public class CachedCalculationService : ICalculationService
    {
        private class Params
        {
            private readonly decimal _a;
            private readonly decimal _b;

            public Params(decimal a, decimal b)
            {
                _a = a;
                _b = b;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;
                var calcParams = (Params) obj;
                return (calcParams._a == _a) && (calcParams._b == _b);
            }

            public override int GetHashCode()
            {
                return _a.GetHashCode() ^ _b.GetHashCode();
            }
        }

        private readonly ICalculationService _calculationService;
        private decimal _calcRes;
        private readonly Dictionary<Params, decimal> _cache = new Dictionary<Params, decimal>();
        public CachedCalculationService(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        public decimal Calculate(decimal a, decimal b)
        {
            var parms = new Params(a, b);
            if (_cache.ContainsKey(parms))
            {
                Console.WriteLine("Cached value found");
                return _cache[parms];
            }

            _calcRes = _calculationService.Calculate(a, b);
            _cache.Add(parms, _calcRes);
            return _calcRes;
        }
    }
}
