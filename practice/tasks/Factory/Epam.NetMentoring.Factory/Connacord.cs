using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory
{
    public class Connacord : IBank
    {
        public string Name { get; private set; }
        public Connacord(string name)
        {
            Name = name;
        }
        public IList<IPosition> Filter(IList<IPosition> positions)
        {
            if (positions == null)
                return new List<IPosition>();
            return positions.Where(s => s.Type == "Future" && (s.Amount >= 30 && s.Amount < 40)).ToList();
        }
    }
}
