using System;

namespace Epam.NetMentoring.Singelton.ServiceContext
{
    public class ServiceContext
    {
        //IT: in you case volotile is not needed!
        private static volatile ServiceContext _context;

        //IT: syncObj seems to be a better name
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
                //IT: each time when you request ServiceContext instance you will do lock, 
                //but actualy we can avoid this lock for each execution
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
