using System.Threading.Tasks;

namespace Epam.Sdesk.Messaging
{
    public interface IConsumer<T> where T: new()
    {
        Task BeginConsumingFromAsync(string queue);
        void BeginConsumingFrom(string queue);
    }
}
