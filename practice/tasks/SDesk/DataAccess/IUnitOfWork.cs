using System;

namespace Epam.Sdesk.DataAccess
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        void Save();
    }
}
