using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class PositionFilter : IPositionFilter
    {
        private const string Option = "Option";
        private const string Future = "Future";
        private const string NyOption = "NyOption";

        public IEnumerable<Position> FilterPositions(IBank bank, IEnumerable<Position> positions)
        {
            if (bank is Barcap)
                return positions.Where(s => s.Type == Option && s.SubType == NyOption && s.Amount >= 50).ToList().AsReadOnly();
            if (bank is Connacord)
                return positions.Where(s => s.Type == Future && (s.Amount >= 30 && s.Amount < 40)).ToList().AsReadOnly();
            if (bank is Bofa)
                return positions.Where(s => s.Amount >= 40).ToList().AsReadOnly();
            return new List<Position>().AsReadOnly();
        }
    }
}
