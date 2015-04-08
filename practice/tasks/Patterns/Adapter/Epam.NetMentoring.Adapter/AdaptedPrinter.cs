using System.Collections.Generic;

namespace Epam.NetMentoring.Adapter
{
    class AdaptedPrinter : IElements<object>
    {
        private readonly IContainer<object> _container;
        readonly Printer _adaptee = new Printer();

        public AdaptedPrinter(IContainer<object> container)
        {
            _container = container;
        }

        public IEnumerable<object> GetElements()
        {
            _adaptee.Print(_container);
            return _container.Items;
        }
    }
}
