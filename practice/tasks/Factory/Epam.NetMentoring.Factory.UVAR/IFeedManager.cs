using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public interface IFeedManager
    {
        IEnumerable<ValidationError> Validate(TradeFeedItem item);
        string Match(TradeFeedItem item);
        //IT: as usual save method return id, all the object with updated id, or void. If somethings goes wrong, method generates exception

        ��� ������� ���� ���� ��� ��� ����, ����� ����� ����
        Guid Save(TradeFeedItem item);
    }
}