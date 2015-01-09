using System.Collections.Generic;

namespace Epam.NetMentoring.RetailEquity
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var positions = new List<Position>();
            positions.Add(new Position("Equity", 100, "AsiaOption"));
            positions.Add(new Position("Equity", 10, "AsiaOption"));
            positions.Add(new Position("Future", 30, "NyOption"));
            positions.Add(new Position("Future", 40, "NyOption"));
            positions.Add(new Position("Option", 56, "NyOption"));

            var factory = new PositionFilterFactory().CreatePositionFilter("Barcap").FilterPositions(positions);

        }
    }
}