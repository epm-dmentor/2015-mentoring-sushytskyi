namespace Epam.NetMentoring.CommandPattern
{
    public interface ICommandProvider
    {
        void AddCommand(string name, IMentoringCommand command);
        IMentoringCommand GetCommand(string name);
    }
}
