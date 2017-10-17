using System.Collections.Generic;

namespace TheAmazingBookStore.Controller.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
