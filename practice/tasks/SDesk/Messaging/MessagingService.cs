using System;
using System.Collections.Specialized;
using System.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;

namespace Epam.Sdesk.Messaging
{
    public class MessagingService:IMessagingService
    {
        #region Fields
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private NameValueCollection _messagingConfig;
        private readonly string _exchangeName;
        private readonly string _hostname;
        private readonly string _user;
        private readonly string _password;
        private readonly string _virtualhost;
        private readonly string _queueOne;
        private readonly string _queueTwo;
        private readonly string _routingKey;
        private IConnection _connection;
        #endregion

        #region Constructor
        public MessagingService () 
        {
            try
            {
                _messagingConfig = ConfigurationManager.GetSection("Messaging") as NameValueCollection;
                _hostname = _messagingConfig["hostname"];
                _user = _messagingConfig["user"];
                _password = _messagingConfig["password"];
                _virtualhost = _messagingConfig["virtualhost"];
                _exchangeName = _messagingConfig["exchangeName"];
                _queueOne = _messagingConfig["queueOne"];
                _queueTwo = _messagingConfig["queueTwo"];
       
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns connection to RabbitMQ Messaging
        /// </summary>
        /// <returns></returns>
        public IConnection GetRabbitMqConnection()
        {

            try
            {
                var connectionFactory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _user,
                    Password = _password,
                    VirtualHost = _virtualhost,
                    Protocol = Protocols.DefaultProtocol,
                    RequestedHeartbeat = 50,
                    Port = AmqpTcpEndpoint.UseDefaultPort
                };

                _log.Info("Successfully connected to RabbitMQ at host ");
                _connection=connectionFactory.CreateConnection();
                
                return _connection;
            }
            
            catch (Exception ex)
            {
                _log.Error("Could not connect to RabbitMq. Exception is: " + ex.Message);
                
                return null;
            }

        }
        /// <summary>
        /// Sets up Exchange and Binds Queues
        /// </summary>
        /// <param name="model"></param>
        public void SetUpExchangeAndQueues(IModel model)
        {
            model.ExchangeDeclare(_exchangeName, ExchangeType.Topic, true);
            model.QueueDeclare(_queueOne, true, false, false, null);
            model.QueueDeclare(_queueTwo, true, false, false, null);
            model.QueueBind(_queueOne, _exchangeName, "");
            model.QueueBind(_queueTwo, _exchangeName, "");
        }
        #endregion
    }
}
