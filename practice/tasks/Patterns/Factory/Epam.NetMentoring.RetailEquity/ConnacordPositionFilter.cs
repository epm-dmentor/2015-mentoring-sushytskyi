using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class ConnacordPositionFilter : IPositionFilter
    {
        private const string Future = "Future";
        private const int AmountFrom = 30;
        private const int AmountTo = 40;

        public IEnumerable<Position> FilterPositions(IEnumerable<Position> positions)
        {
            return positions.Where(s => s.Type == Future && (s.Amount >= AmountFrom && s.Amount < AmountTo)).ToList().AsReadOnly();
        }
    }
}
