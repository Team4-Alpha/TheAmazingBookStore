﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;

namespace TheAmazingBookStore.Controller.Core.Factories
{
    class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}