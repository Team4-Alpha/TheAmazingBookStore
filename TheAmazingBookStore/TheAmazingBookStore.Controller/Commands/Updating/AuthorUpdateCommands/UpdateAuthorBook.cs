using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Updating.AuthorUpdateCommands
{
   public class UpdateAuthorBook:ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateAuthorBook(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }
        //TODO update author book not working
        public string Execute(IList<string> parameters)
        {
            int authorID = int.Parse(parameters[0]);
            var book = (parameters[1]);

            //var obj= this.context.Authors.First(b => b.Id == authorID).Books;
            List<Book> books = this.context.Books.Where(b => b.Title == book).ToList();


            this.context.Authors.Where(b => b.Id == authorID).ToList()[0].Books = books;

            this.context.SaveChanges();
            return $"Authors book has been added to \"{this.context.Authors.First(b => b.Id == authorID).Books}\".";
        }
    }
}
