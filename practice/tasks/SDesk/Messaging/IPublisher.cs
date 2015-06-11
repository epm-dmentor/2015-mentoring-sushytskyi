using System.Threading.Tasks;

namespace Epam.Sdesk.Messaging
{
    public interface IPublisher<T> where T : new()
    {
        Task PublishAsync(T messageEntity);
    }
}
