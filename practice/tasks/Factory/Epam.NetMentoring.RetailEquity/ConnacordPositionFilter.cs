using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class ConnacordPositionFilter : IPositionFilter
    {
        private const string Future = "Future";

        public IEnumerable<Position> FilterPositions(IEnumerable<Position> positions)
        {
            return positions.Where(s => s.Type == Future && (s.Amount >= 30 && s.Amount < 40)).ToList().AsReadOnly();
        }
    }
}
