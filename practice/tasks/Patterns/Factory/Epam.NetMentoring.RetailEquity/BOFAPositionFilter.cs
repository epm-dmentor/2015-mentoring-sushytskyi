using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class BofaPositionFilter : IPositionFilter
    {
        private const int AmountFrom = 40;
        public IEnumerable<Position> FilterPositions(IEnumerable<Position> positions)
        {
            return positions.Where(s => s.Amount >= AmountFrom).ToList();
        }
    }
}
