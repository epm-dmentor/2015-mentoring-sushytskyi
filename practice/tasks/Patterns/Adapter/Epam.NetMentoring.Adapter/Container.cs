using System.Collections.Generic;

namespace Epam.NetMentoring.Adapter
{
    public class Container : IContainer<object>
    {
        private readonly List<object> _items = new List<object>() { new object(), new object(), new object() };

        public IEnumerable<object> Items
        {
            get { return _items; }
            private set { }
        }

        public int Count
        {
            get { return _items.Count; }
            private set { }
        }
    }
}
