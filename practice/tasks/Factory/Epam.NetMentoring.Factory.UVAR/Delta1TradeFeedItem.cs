using System;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class Delta1TradeFeedItem : TradeFeedItem
    {
        public string SecurityId { get; set; }
        public string Market { get; set; }

        public Delta1TradeFeedItem()
        {
        }
        
        //IT: better to remove such huge constructor, it's not good approach
        public Delta1TradeFeedItem(int stagingId, string sourceTradeRef, int counterpartyId, int principalId, DateTime valuationDate, decimal currentPrice, int sourceAccountId, string securityId, string market)
            : base(stagingId, sourceTradeRef, counterpartyId, principalId, valuationDate, currentPrice, sourceAccountId)
        {
            SecurityId = securityId;
            Market = market;
        }
    }
}
