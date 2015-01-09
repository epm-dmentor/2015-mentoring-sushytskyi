using System.Collections.Generic;

namespace Epam.NetMentoring.Factory
{
    public interface IEquityFilter
    {
        IList<IPosition> FilterPositions(string bankName);
    }
}