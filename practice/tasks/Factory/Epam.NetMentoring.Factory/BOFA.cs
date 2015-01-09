using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory
{
    class Bofa : IBank
    {
        public string Name { get; private set; }
        public Bofa(string name)
        {
            Name = name;
        }
        public IList<IPosition> Filter(IList<IPosition> positions)
        {
            if (positions == null)
                return new List<IPosition>();
            return positions.Where(s => s.Amount >= 40).ToList();
        }
    }
}
