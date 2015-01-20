using System;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class TradeFeedItem : ITradeFeedItem
    {
        public int StagingId { get; set; }
        public string SourceTradeRef { get; set; }
        public int CounterpartyId { get; set; }
        public int PrincipalId { get; set; }
        public DateTime ValuationDate { get; set; }
        public decimal CurrentPrice { get; set; }
        public int SourceAccountId { get; set; }

        public TradeFeedItem()
        {
        }

        public TradeFeedItem(int stagingId, string sourceTradeRef, int counterpartyId, int principalId, DateTime valuationDate, decimal currentPrice, int sourceAccountId)
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
