using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public interface IFeedManager
    {
        IEnumerable<string> Validate(ITradeFeedItem item);
        string Match(ITradeFeedItem item);
        //IT: as usual save method return id, all the object with updated id, or void. If somethings goes wrong, method generates exception
        bool Save(ITradeFeedItem item);
    }
}