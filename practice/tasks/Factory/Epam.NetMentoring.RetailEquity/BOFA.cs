using System.Collections.Generic;

namespace Epam.NetMentoring.RetailEquity
{
    class Bofa : IBank
    {
        private readonly IPositionFilter _equityFilter;
        public Bofa(IPositionFilter equityFilter)
        {
            _equityFilter = equityFilter;
        }

        public IEnumerable<Position> Filter(IEnumerable<Position> positions)
        {
            return _equityFilter.FilterPositions(this, positions);
        }
    }
}
