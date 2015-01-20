using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class BarcapPositionFilter : IPositionFilter
    {
        private const string Option = "Option";
        private const string NyOption = "NyOption";
        private const int AmountFrom = 50;

        public IEnumerable<Position> FilterPositions(IEnumerable<Position> positions)
        {
            return positions.Where(s => s.Type == Option && s.SubType == NyOption && s.Amount >= AmountFrom).ToList();
        }
    }
}
