using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;

namespace Epam.Sdesk.Messaging
{
    public class Publisher<T> : IPublisher<T> where T : new()
    {

        #region Fields
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private NameValueCollection _messagingConfig;
        private readonly string _exchangeName;
        private readonly string _routingKey;
        #endregion

        #region Constructor
        public Publisher()
        {
            try
            {
                _messagingConfig = ConfigurationManager.GetSection("Messaging") as NameValueCollection;
                _exchangeName = _messagingConfig["exchangeName"];
            }
            catch (Exception ex)
            {
                _log.Fatal("Fatal error creating Publisher. Please check exception: \n" + ex.Message);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Publishes Generic Entity to RabbitMQ Exchange
        /// </summary>
        /// <param name="messageEntity"></param>
        /// <returns></returns>
        public async Task PublishAsync(T messageEntity)
        {
            await Task.Factory.StartNew(() =>
            {
                var serializer = new Serializer<T>();
                var service = new MessagingService();
                using (var connection = service.GetRabbitMqConnection())
                {
                    var model = connection.CreateModel();
                    service.SetUpExchangeAndQueues(model);
                    var basicProperties = model.CreateBasicProperties();
                    basicProperties.SetPersistent(true);
                    var messageBytes = serializer.Serialize(messageEntity);
                    model.BasicPublish(_exchangeName, "", basicProperties, messageBytes);
                    _log.Info("Message has been published to Exchange " + _exchangeName);
                }
            });
        }

        public void Publish(T messageEntity)
        {
            var serializer = new Serializer<T>();
            var service = new MessagingService();
            using (var connection = service.GetRabbitMqConnection())
            {
                var model = connection.CreateModel();
                service.SetUpExchangeAndQueues(model);
                var basicProperties = model.CreateBasicProperties();
                basicProperties.SetPersistent(true);
                var messageBytes = serializer.Serialize(messageEntity);
                model.BasicPublish(_exchangeName, "", basicProperties, messageBytes);
                _log.Info("Message has been published to Exchange " + _exchangeName);
            }

        }

        #endregion
    }
}
