using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public interface IFeedManager
    {
        IEnumerable<ValidationError> Validate(TradeFeedItem item);
        string Match(TradeFeedItem item);
        Guid Save(TradeFeedItem item);
    }
}