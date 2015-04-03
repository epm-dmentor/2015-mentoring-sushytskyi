using System.Collections.Generic;

namespace Epam.NetMentoring.CommandPattern
{
    public class CommandProvider : ICommandProvider
    {
        private readonly Dictionary<string, IMentoringCommand> _commands = new Dictionary<string, IMentoringCommand>();

        public void AddCommand(string name, IMentoringCommand command)
        {
            _commands[name] = command;
        }

        public IMentoringCommand GetCommand(string name)
        {
            return _commands[name];
        }
    }
}
