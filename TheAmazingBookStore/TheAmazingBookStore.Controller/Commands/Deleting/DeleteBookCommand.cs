using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Deleting
{
    public class DeleteBookCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public DeleteBookCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            string title = parameters[0];
            this.context.Books.Remove(this.context.Books.Where(b => b.Title == title).ToList()[0]);
            this.context.SaveChanges();
            return "deleted";
        }
    }
}
