using System.Collections.Generic;


namespace Epam.NetMentoring.Factory.UVAR
{
    public class D1TradeFeed : TradeFeed
    {
        public D1TradeFeed(IEnumerable<D1Record> feedRecords)
            : base(feedRecords)
        {
        }
    }
}
