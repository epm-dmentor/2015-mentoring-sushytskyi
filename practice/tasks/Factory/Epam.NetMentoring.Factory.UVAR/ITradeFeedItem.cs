using System;

namespace Epam.NetMentoring.Factory.UVAR
{
    //IT: do not use interface for model, such approach is not used as usual. It's jsut not needed
    public interface ITradeFeedItem
    {
        int StagingId { get; set; }
        string SourceTradeRef { get; set; }
        int CounterpartyId { get; set; }
        int PrincipalId { get; set; }
        DateTime ValuationDate { get; set; }
        decimal CurrentPrice { get; set; }
        int SourceAccountId { get; set; }
    }
}