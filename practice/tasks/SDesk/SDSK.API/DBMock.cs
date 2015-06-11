using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Epam.Sdesk.Model;

namespace SDSK.API
{
    public class DBMock
    {
        private List<Mail> _mails = new List<Mail>();
        private List<Attachement> _attachments = new List<Attachement>();

        public DBMock()
        {
            _mails.Add(
                new Mail()
                {
                    AttachementId = 1,
                    Body = "1st Mail",
                    Cc = "IF@ukr.net",
                    Id = 1,
                    Priority = Priority.High,
                    Received = new DateTime(),
                    Saved = new DateTime(),
                    Sender = "IS@ukr.net",
                    Subject = "First Mail",
                    To = "gb@ukr.net"
                });
            _mails.Add(
                new Mail()
                {
                    AttachementId = 1,
                    Body = "2nd Mail",
                    Cc = "Ib@ukr.net",
                    Id = 2,
                    Priority = Priority.High,
                    Received = new DateTime(),
                    Saved = new DateTime(),
                    Sender = "In@ukr.net",
                    Subject = "Second Mail",
                    To = "gv@ukr.net"
                });

            _attachments.Add(
                new Attachement()
                {
                    Id = 1,
                    FileExtention = "txt",
                    FileName = "test",
                    MailId = 1,
                    Path = "c:",
                    StatusId = 43
                });
            _attachments.Add(
                new Attachement()
                {
                    Id = 2,
                    FileExtention = "bmp",
                    FileName = "mest",
                    MailId = 1,
                    Path = "D:",
                    StatusId = 53
                });
            _attachments.Add(
                            new Attachement()
                            {
                                Id = 3,
                                FileExtention = "bmv",
                                FileName = "mestyyy",
                                MailId = 2,
                                Path = "V:",
                                StatusId = 63
                            });

        }

        public IEnumerable<Mail> Mails
        {
            get { return _mails; }
            set
            {
                _mails.AddRange(value);
            }
        }
        public IEnumerable<Attachement> Attacments
        {
            get { return _attachments; }
            set
            {
                _attachments.AddRange(value);
            }
        }
    
    }
}
