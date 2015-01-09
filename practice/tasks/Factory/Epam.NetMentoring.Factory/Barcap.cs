using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory
{
    public class Barcap : IBank
    {
        public string Name { get; private set; }
        public Barcap(string name)
        {
            Name = name;
        }

        public IList<IPosition> Filter(IList<IPosition> positions)
        {
            if (positions == null)
                return new List<IPosition>();
            return positions.Where(s => s.Type == "Option" && s.SubType == "NyOption" && s.Amount >= 50).ToList();
        }

    }
}
