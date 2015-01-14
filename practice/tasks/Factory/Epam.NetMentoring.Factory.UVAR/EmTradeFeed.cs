using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class EmTradeFeed : TradeFeed
    {

        public EmTradeFeed(IEnumerable<EmRecord> records)
            : base(records)
        {

        }
    }
}
