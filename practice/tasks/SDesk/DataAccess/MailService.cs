using System.Collections.Generic;
using Epam.Sdesk.Model;

namespace Epam.Sdesk.DataAccess
{
    public class MailService
    {
        private IRepository<Mail> _repo;
     
        public MailService(IUnitOfWork unit)
        {
            _repo = unit.GetRepository<Mail>();
        }

        public void Add(Mail mail)
        {
            _repo.Add(mail);
        }

        public IEnumerable<Mail> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
