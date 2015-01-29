using System;

namespace Epam.NetMentoring.Singelton.ServiceContext
{
    public class ServiceContext
    {
        private static volatile ServiceContext _context;
        private static readonly object Synch = new object();
        public Guid ConnectionId { get; private set; }

        private ServiceContext(Guid connectionId)
        {
            ConnectionId = connectionId;
        }

        public static ServiceContext Context
        {
            get
            {
                lock (Synch)
                {
                    if (_context == null)
                        _context = new ServiceContext(Guid.NewGuid());
                }
                return _context;
            }
        }

    }
}
