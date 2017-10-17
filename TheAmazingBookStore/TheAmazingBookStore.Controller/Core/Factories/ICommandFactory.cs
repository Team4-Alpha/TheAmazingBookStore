using TheAmazingBookStore.Controller.Commands.Contracts;

namespace TheAmazingBookStore.Controller.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
