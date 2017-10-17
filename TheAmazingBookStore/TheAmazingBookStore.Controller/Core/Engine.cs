using Bytes2you.Validation;
using System;
using TheAmazingBookStore.Controller.Core.Contracts;

namespace TheAmazingBookStore.Controller.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;
        private readonly IProcessor processor;

        public Engine(IReader reader, IWriter writer, IParser parser, IProcessor processor)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(parser, "parser").IsNull().Throw();
            Guard.WhenArgument(processor, "processor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.parser = parser;
            this.processor = processor;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    processor.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        
    }
}
