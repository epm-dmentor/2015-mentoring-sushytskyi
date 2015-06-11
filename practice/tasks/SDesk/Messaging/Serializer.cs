using System.Text;

namespace Epam.Sdesk.Messaging
{
    public class Serializer<T> : ISerializer<T> where T: new()
    {

        #region Methods
        public byte[] Serialize(T messageEntity)
        {
            var jsonString = Newtonsoft.Json.JsonConvert.
                SerializeObject(messageEntity);
            return Encoding.Default.GetBytes(jsonString);
        }

        public T Deserialize(byte[] messageBody)
        {
            var jsonString = Encoding.Default.GetString(messageBody);
            return (T)Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
        }
        #endregion
    }
}
