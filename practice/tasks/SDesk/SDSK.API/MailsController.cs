using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using Epam.Sdesk.Model;
using Newtonsoft.Json;

namespace SDSK.API
{
    public class MailsController : ApiController
    {

        DBMock _mock = new DBMock();

        public IHttpActionResult Get()
        {
            return Ok(_mock.Mails);
        }

        [ResponseType(typeof(Mail))]
        public IHttpActionResult Get(int id)
        {
            var content =(_mock.Mails.FirstOrDefault(s => s.Id == id));
            return Ok(content);
        }

        public IHttpActionResult Put(int id, Mail mail)
        {
            var convertedList = _mock.Mails.ToList();
            convertedList.Remove(_mock.Mails.FirstOrDefault(s => s.Id == id));
            _mock.Mails = convertedList;
            var mails = new List<Mail>();
            mails.Add(mail);
            _mock.Mails = mails;
            return Ok(_mock.Mails.FirstOrDefault(s => s.Id == id));
        }

        public IHttpActionResult Post([FromBody]Mail mail)
        {
            var mails = new List<Mail>();
            mails.Add(mail);
            _mock.Mails = mails;
            return Ok();
        }

        [Route("api/mails/{id}/attachments")]
        [HttpGet]
        public IHttpActionResult GetMailAttachments(int id)
        {          
            return Ok(_mock.Attacments.Where(s=>s.MailId==id));
        }

        [Route("api/mails/{id}/attachments/{attid}")]
        [HttpGet]
        public IHttpActionResult GetMailAttachments(int id, int attid)
        {
            return Ok(_mock.Attacments.Where(s => s.MailId == id&&s.Id==attid));
        }

        [Route("api/mails/{id}/attachments/{attid}")]
        [HttpGet]
        public IHttpActionResult GetMailAttachments(int id, int attid,string ext)
        {
            return Ok(_mock.Attacments.Where(s => s.MailId == id && s.Id == attid &&s.FileExtention==ext));
        }

        [Route("api/mails/{id}/attachments/{attid}")]
        [HttpGet]
        public IHttpActionResult GetMailAttachments(int id, int attid, string ext,int status)
        {
            return Ok(_mock.Attacments.Where(s => s.MailId == id && s.Id == attid && s.FileExtention == ext&&s.StatusId==status));
        }

        [Route("api/mails/{id}/attachments/{attid}")]
        [HttpPut]
        public IHttpActionResult PutMailAttachment(int id, int attid,[FromBody]Attachement attachment)
        {
            var convertedList = _mock.Attacments.ToList();
            convertedList.Remove(_mock.Attacments.FirstOrDefault(s => s.Id == attid&&s.MailId==id));
            _mock.Attacments = convertedList;
            var attachmentsList = new List<Attachement>();
            attachmentsList.Add(attachment);
            _mock.Attacments = attachmentsList;
            return Ok(_mock.Attacments.FirstOrDefault(s => s.Id == attid && s.MailId == id));
        }


    }
}
