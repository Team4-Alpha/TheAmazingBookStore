using System.Collections.Generic;
using TheAmazingBookStore.Controller.Commands.Contracts;

namespace TheAmazingBookStore.Controller.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
