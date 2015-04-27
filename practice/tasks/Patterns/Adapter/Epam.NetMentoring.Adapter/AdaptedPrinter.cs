using System.Collections.Generic;

namespace Epam.NetMentoring.Adapter
{
    class ElementsContainer : IElements<object>
    {
        private IEnumerable<object> items;
        public ElementsContainer(IEnumerable<object> items)
        {
            this.items = items;
        }

        public IEnumerable<object> GetElements()
        {
            return items;
        }
    }
}
