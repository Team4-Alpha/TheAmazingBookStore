using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

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
            List<Book> books = this.context.Books.Where(b => b.Title == title).ToList();
            this.context.Books.Remove(books[0]);
            this.context.SaveChanges();
            return "deleted";
        }
    }
}
