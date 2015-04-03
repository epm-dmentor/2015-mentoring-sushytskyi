using System.Collections.Generic;

namespace Epam.NetMentoring.RetailEquity
{
    public interface IPositionFilter
    {
        IEnumerable<Position> FilterPositions(IEnumerable<Position> positions);
    }
}
