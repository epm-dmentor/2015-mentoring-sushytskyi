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
        //IS: Your comment regarding useless of big constructors I remember. But just to reduce amount of code to change
        //IS: for that particular example I left objects instantiation via constructor but made fields mutable and defined default constructor
        //IS: but if you are not ok with that i will change it.
        public Delta1TradeFeedItem(int stagingId, string sourceTradeRef, int counterpartyId, int principalId, DateTime valuationDate, decimal currentPrice, int sourceAccountId, string securityId, string market)
            : base(stagingId, sourceTradeRef, counterpartyId, principalId, valuationDate, currentPrice, sourceAccountId)
        {
            SecurityId = securityId;
            Market = market;
        }
    }
}
