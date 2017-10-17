using System;
using TheAmazingBookStore.Controller.Core.Contracts;

namespace TheAmazingBookStore.Controller.Core.Providers
{
    public class CommandProcessor : IProcessor
    {
        private readonly IParser parser;
        private readonly IWriter writer;

        public CommandProcessor(IParser parser, IWriter writer)
        {
            this.writer = writer;
            this.parser = parser;
        }

        public void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            writer.WriteLine(executionResult);
        }
    }
}
