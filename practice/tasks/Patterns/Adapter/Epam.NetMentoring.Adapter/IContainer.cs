using System.Collections.Generic;

namespace Epam.NetMentoring.Adapter
{
    public interface IContainer<T>
    {
        IEnumerable<object> Items { get; }
        int Count { get; }
    }
}