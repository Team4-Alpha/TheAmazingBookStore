using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Update.BookUpdateCommands
{
    public class UpdateBookTitle : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateBookTitle(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int bookId = int.Parse(parameters[0]);
            string newTitle = string.Empty;
            for (int i = 1; i < parameters.Count(); i++)
            {
                newTitle += parameters[i] + " ";
            }
            newTitle = newTitle.TrimEnd(' ');
            this.context.Books.Where(b => b.Id == bookId).ToList()[0].Title = newTitle;
            this.context.SaveChanges();
            return $"The book's title has been changed to \"{this.context.Books.Where(b => b.Id == bookId).ToList()[0].Title}\".";
        }
    }
}
