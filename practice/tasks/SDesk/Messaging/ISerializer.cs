namespace Epam.Sdesk.Messaging
{
    public interface ISerializer<T> where T : new()
    {
        byte[] Serialize(T messageEntity);
        T Deserialize(byte[] messageBody);
    }
}
