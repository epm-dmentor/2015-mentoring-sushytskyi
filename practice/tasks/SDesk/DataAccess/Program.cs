using System;
using System.Linq;
using Epam.Sdesk.Model;

namespace Epam.Sdesk.DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitofwork = new UnitOfWork<SdeskContext>();
            var service = new MailService(unitofwork);
            var mail = new Mail
            {
                AttachementId = 12,
                Body = "Test body",
                Cc = "bayram@gmail.com",
                Id = 111,
                Priority = Priority.High,
                Received = DateTime.Today,
                Saved = DateTime.Today,
                Sender = "test@tes.com",
                Subject = "High",
                To = "me@me.com"
            };

            
            service.Add(mail);


            unitofwork.Save();

            
            var result = service.GetAll().ToList();
            
            
            foreach (var item in result)
            {
                Console.WriteLine(item.Body);
            }
            Console.ReadKey();
        }
    }
}
