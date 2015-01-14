using System;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class EmRecord : Record
    {
        public int BrokerId { get; private set; }
        public string Comments { get; private set; }

        public EmRecord(int stagingId, string sourceTradeRef, int counterpartyId, int principalId, DateTime valuationDate, decimal currentPrice, int sourceAccountId, int brokerId, string comments)
            : base(stagingId, sourceTradeRef, counterpartyId, principalId, valuationDate, currentPrice, sourceAccountId)
        {
            BrokerId = brokerId;
            Comments = comments;
        }
    }
}
