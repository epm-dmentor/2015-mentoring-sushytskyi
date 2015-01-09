using System.Collections.Generic;

namespace Epam.NetMentoring.RetailEquity
{
    public interface IBank
    {
        IEnumerable<Position> Filter(IEnumerable<Position> positions);
    }
}
