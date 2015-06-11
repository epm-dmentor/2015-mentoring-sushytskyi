using RabbitMQ.Client;

namespace Epam.Sdesk.Messaging
{
    public interface IMessagingService
    {
        IConnection GetRabbitMqConnection();
        void SetUpExchangeAndQueues(IModel model);
    }
}
