using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Adapter
{
    public class Container : IContainer<object>
    {
        private readonly IEnumerable<object> _items;

        public Container(IEnumerable<object> items)
        {
            _items = items;
        }

        public IEnumerable<object> Items
        {
            get { return _items; }
            private set { }
        }

        public int Count
        {
            get { return _items.Count(); }
            private set { }
        }
    }
}
