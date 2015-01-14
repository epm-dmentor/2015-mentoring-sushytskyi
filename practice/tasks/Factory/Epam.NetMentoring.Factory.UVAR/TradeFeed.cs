using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class TradeFeed
    {
        public IEnumerable<Record> Records { get; private set; }

        public TradeFeed(IEnumerable<Record> feedRecords)
        {
            Records = feedRecords;
        }
    }
}
