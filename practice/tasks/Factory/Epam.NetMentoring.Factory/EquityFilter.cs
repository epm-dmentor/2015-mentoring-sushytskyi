using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory
{
    public class EquityFilter : IEquityFilter
    {
        private readonly IBankFactory _bankFactory;
        private readonly IList<IPosition> _positions;
        public EquityFilter(IBankFactory bankFactory, IList<IPosition> positions)
        {
            _bankFactory = bankFactory;
            _positions = positions;
        }
        public IList<IPosition> FilterPositions(string bankName)
        {
            var bank = _bankFactory.CreateBank(bankName);
            List<IPosition> res;
            
            try
            {
                res = bank.Filter(_positions).ToList();
            }
            catch (NullReferenceException ex)
            {               
                Console.WriteLine("No bank found");
                Console.WriteLine(ex.Message);             
                res = new List<IPosition>();
            }
            return res.AsReadOnly();
        }

    }
}
