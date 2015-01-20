using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public interface IFeedManager
    {
        IEnumerable<string> Validate(ITradeFeedItem item);
        string Match(ITradeFeedItem item);
        bool Save(ITradeFeedItem item);
    }
}