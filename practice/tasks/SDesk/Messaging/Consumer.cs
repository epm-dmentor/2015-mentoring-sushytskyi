using System.Threading.Tasks;
using RabbitMQ.Client.MessagePatterns;

namespace Epam.Sdesk.Messaging
{
    public class Consumer<T> : IConsumer<T> where T: new()
    {
        #region Fields
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public delegate void OnMessageReceive(T message);
        public event OnMessageReceive MessageReceived;
        #endregion

        #region Methods

        protected virtual void OnMessageReceived(T message)
        {
            var handler = MessageReceived;
            if (handler != null)
            {
                handler(message);
            }
        }
        /// <summary>
        /// Begin consuming messages from given queue Async
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        public async Task BeginConsumingFromAsync(string queue)
        {
            var serializer = new Serializer<T>();
            var service = new MessagingService();

            using (var connection = service.GetRabbitMqConnection())
            {
                var model = connection.CreateModel();
                service.SetUpExchangeAndQueues(model);
                var subscription = new Subscription(model, queue, true);
                await Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        var message = subscription.Next();
                        var body = message.Body;
                        var entity = serializer.Deserialize(body);
                        OnMessageReceived(entity);
                        subscription.Ack(message);
                    }

                });
            }
        }
        /// <summary>
        ///Begin consuming messages from given queue Sync
        /// </summary>
        /// <param name="queue"></param>
        public void BeginConsumingFrom(string queue)
        {
            var serializer = new Serializer<T>();
            var service = new MessagingService();

            using (var connection = service.GetRabbitMqConnection())
            {
                var model = connection.CreateModel();
                service.SetUpExchangeAndQueues(model);
                var subscription = new Subscription(model, queue, true);
                while (true)
                {
                    var message = subscription.Next();
                    var body = message.Body;
                    var entity = serializer.Deserialize(body);
                    OnMessageReceived(entity);
                    subscription.Ack(message);
                    _log.Info("Received Message from queue :" +queue + " message: "+ body);
                }
            }
        }
        #endregion
    }
}
