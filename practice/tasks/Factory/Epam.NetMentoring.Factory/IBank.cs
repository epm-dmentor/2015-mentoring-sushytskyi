using System.Collections.Generic;

namespace Epam.NetMentoring.Factory
{
    public interface IBank
    {
        string Name { get; }
        IList<IPosition> Filter(IList<IPosition> positions);
    }
}
