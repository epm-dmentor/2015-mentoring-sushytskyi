using System.Collections.Generic;

namespace Epam.NetMentoring.Factory
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var positions = new List<IPosition>();
            positions.Add(new Position("Equity", 100, "AsiaOption"));
            positions.Add(new Position("Equity", 10, "AsiaOption"));
            positions.Add(new Position("Future", 30, "NyOption"));
            positions.Add(new Position("Future", 40, "NyOption"));
            positions.Add(new Position("Option", 56, "NyOption"));

            var retail = new EquityFilter(new BankFactory(), positions);
            var filteredPositions = retail.FilterPositions("Barcap");
            var filteredPositions1 = retail.FilterPositions("Connacord");
         //   var filteredPositions3 = retail.FilterPositions("sdf");

        }
    }
}