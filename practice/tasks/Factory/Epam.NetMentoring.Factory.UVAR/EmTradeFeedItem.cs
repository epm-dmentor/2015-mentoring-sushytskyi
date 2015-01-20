using System;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class EmTradeFeedItem : TradeFeedItem
    {
        public int BrokerId { get; set; }
        public string Comments { get; set; }

        public EmTradeFeedItem(int stagingId, string sourceTradeRef, int counterpartyId, int principalId, DateTime valuationDate, decimal currentPrice, int sourceAccountId, int brokerId, string comments)
            : base(stagingId, sourceTradeRef, counterpartyId, principalId, valuationDate, currentPrice, sourceAccountId)
        {
            BrokerId = brokerId;
            Comments = comments;
        }
    }
}
