using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Updating.AuthorUpdateCommands
{
    public class UpdateAuthorBooks:ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateAuthorBooks(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }
        //TODO update author book not working
        public string Execute(IList<string> parameters)
        {
            int authorId = int.Parse(parameters[0]);
            var bookString = (parameters[1]);
            
            var book = this.context.Books.First(b => b.Title == bookString);

            var author = this.context.Authors.Find(authorId);
            author.Books.Add(book);

            this.context.SaveChanges();
            return $"{book.Title} has been added to {author.FirstName} {author.LastName}.";
        }
    }
}
