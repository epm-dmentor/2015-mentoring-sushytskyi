using System.Collections.Generic;

namespace Epam.NetMentoring.Adapter
{
    public interface IElements<T>
    {
        IEnumerable<T> GetElements();
    }
}
