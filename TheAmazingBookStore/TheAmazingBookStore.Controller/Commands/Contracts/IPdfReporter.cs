using System.Collections.Generic;

namespace TheAmazingBookStore.Controller.Commands.Contracts
{
    public interface IPdfReporter
    {
        string Execute(IList<string> parameters);

    }
}
