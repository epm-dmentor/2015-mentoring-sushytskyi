using System.Collections.Generic;

namespace Epam.NetMentoring.RetailEquity
{
    public class Barcap : IBank
    {
        private readonly IPositionFilter _equityFilter;
        public Barcap(IPositionFilter equityFilter)
        {
            _equityFilter = equityFilter;
        }

        public IEnumerable<Position> Filter(IEnumerable<Position> positions)
        {
            return _equityFilter.FilterPositions(this, positions);
        }

    }
}
