using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class BofaPositionFilter : IPositionFilter
    {
        public IEnumerable<Position> FilterPositions(IEnumerable<Position> positions)
        {
            return positions.Where(s => s.Amount >= 40).ToList().AsReadOnly();
        }
    }
}
