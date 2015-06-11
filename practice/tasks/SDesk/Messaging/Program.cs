using System;
using Epam.Sdesk.Model;

namespace Epam.Sdesk.Messaging
{
    public class Program
    {
        private static void Main(string[] args)
        {
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

            var mail1 = new Mail
            {
                AttachementId = 12,
                Body = "Test body 2",
                Cc = "bayram@gmail.com",
                Id = 111,
                Priority = Priority.High,
                Received = DateTime.Today,
                Saved = DateTime.Today,
                Sender = "test@tes.com",
                Subject = "High",
                To = "me@me.com"
            };
           
            var publisher = new Publisher<Mail>();
            publisher.Publish(mail);
            publisher.Publish(mail1);
            
            var consumer = new Consumer<Mail>();
            consumer.MessageReceived += consumer_MessageReceived;
            consumer.BeginConsumingFrom("MyMessageQ1");
            //publisher.Publish(mail);
            Console.ReadKey();
        }

        static void consumer_MessageReceived(Mail message)
        {
            Console.WriteLine(message.Body);
        }
    }
}
