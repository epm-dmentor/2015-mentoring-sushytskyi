namespace Mailing
{
  public  interface IMailReader
    {
        void Connect(MapConfig config);
        void Authentificate(MapConfig config);
        void DeleteMessage(uint uid);
        event NewMailDelagate NewMailArrived;
    }
}
