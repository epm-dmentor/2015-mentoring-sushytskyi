using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public interface IFeedManager
    {
        bool TryValidate(out List<string> errors);
        IEnumerable<string> MatchFeed();
        void Save();
    }
}