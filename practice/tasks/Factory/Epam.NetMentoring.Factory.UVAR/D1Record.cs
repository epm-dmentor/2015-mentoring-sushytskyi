using System;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class D1Record : Record
    {
        public string SecurityId { get; private set; }
        public string Market { get; private set; }

        public D1Record(int stagingId, string sourceTradeRef, int counterpartyId, int principalId, DateTime valuationDate, decimal currentPrice, int sourceAccountId, string securityId, string market)
            : base(stagingId, sourceTradeRef, counterpartyId, principalId, valuationDate, currentPrice, sourceAccountId)
        {
            SecurityId = securityId;
            Market = market;
        }
    }
}
