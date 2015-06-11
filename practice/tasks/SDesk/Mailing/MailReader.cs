using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using S22.Imap;

namespace Mailing
{
    public class MailReader:IMailReader,IMailWatcher
    {
        public event NewMailDelagate NewMailArrived;

        private readonly MapConfig _imapConfig = new MapConfig();
        private readonly Timer _timer;
        private IImapClient _client;
        private const int CheckInterval = 3000;
        private readonly object _lockObj = new object();
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger
(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MailReader()
        {
            _timer = new Timer(CheckInterval);
            _timer.Elapsed += ChekForNewMail;

        }

        public void Connect(MapConfig config)
        {
            try
            {
                _log.Info("Connecting to SMTP server");
                _client = new ImapClient(config.Host, config.Port, config.Ssl);
                _log.Info("logging to SMTP server");
                this.Authentificate(config);
            }
            catch (Exception ex)
            {

                _log.Error(ex);
            }
            
        }

        public void Authentificate(MapConfig config)
        {
            _client.Login(config.Mail, config.Password, AuthMethod.Login);
        }

        public void StartMailWatch()
        {
            if (!_timer.Enabled)
                _timer.Start();

        }

        public void StopMailWatch()
        {
            if (_timer.Enabled)
                _timer.Stop();
        }

        private void Disconnect()
        {
            _log.Info("disconecting from SMTP");
            _client.Logout();
            _client.Dispose();
        }

        private void ChekForNewMail(object sender, ElapsedEventArgs e)
        {
 
            lock (_lockObj)
            {
                Connect(_imapConfig);

                IEnumerable<uint> uids = _client.Search(SearchCondition.Seen());
                _log.Info("New mails received: "+uids.Count());

                if (NewMailArrived != null)
                    foreach (var uid in uids)
                    {
                        var message = _client.GetMessage(uid);
                        NewMailArrived(message, uid);
                    }

                Disconnect();
            }
        }

        public void DeleteMessage(uint uid)
        {
            _client.DeleteMessage(uid);
        }


    }
}
