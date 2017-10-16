using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Core.Contracts;

namespace TheAmazingBookStore.Controller.Core.Providers
{
    class CommandParser : IParser
    {
        //TODO
        public ICommand ParseCommand(string fullCommand)
        {
            throw new NotImplementedException();
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            throw new NotImplementedException();
        }
    }
}
