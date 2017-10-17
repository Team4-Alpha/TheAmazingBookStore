using System;
using TheAmazingBookStore.Controller.Core.Contracts;

namespace TheAmazingBookStore.Controller.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
