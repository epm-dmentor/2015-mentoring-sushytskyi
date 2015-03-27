namespace Epam.NetMentoring.Config
{
    public interface IConfigProvider
    {
        T Resolve<T>() where T : new();

    }
}
