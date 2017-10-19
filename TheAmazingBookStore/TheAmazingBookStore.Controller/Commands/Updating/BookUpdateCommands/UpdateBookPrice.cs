using Bytes2you.Validation;
using System.Collections.Generic;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Updating.BookUpdateCommands
{
    public class UpdateBookPrice : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateBookPrice(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int bookId = int.Parse(parameters[0]);
            decimal newPrice = decimal.Parse(parameters[1]);
            this.context.Books.Find(bookId).Price = newPrice;
            this.context.SaveChanges();
            return $"The book's price has been changed to \"{this.context.Books.Find(bookId).Price}\".";
        }
    }
}
