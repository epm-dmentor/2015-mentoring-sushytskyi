using System;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Mailing
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new MailReader();
            r.StartMailWatch();
            r.NewMailArrived += (mail, uid) => Console.WriteLine(mail.Body);
            while (Console.ReadLine() != "q")
                continue;

        }
    }
}
