using System;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class Record
    {
        public int StagingId { get; private set; }
        public string SourceTradeRef { get; private set; }
        public int CounterpartyId { get; private set; }
        public int PrincipalId { get; private set; }
        public DateTime ValuationDate { get; private set; }
        public decimal CurrentPrice { get; private set; }
        public int SourceAccountId { get; private set; }

        public Record(int stagingId, string sourceTradeRef, int counterpartyId, int principalId, DateTime valuationDate, decimal currentPrice, int sourceAccountId)
        {
            StagingId = stagingId;
            SourceTradeRef = sourceTradeRef;
            CounterpartyId = counterpartyId;
            PrincipalId = principalId;
            ValuationDate = valuationDate;
            CurrentPrice = currentPrice;
            SourceAccountId = sourceAccountId;
        }
    }
}
