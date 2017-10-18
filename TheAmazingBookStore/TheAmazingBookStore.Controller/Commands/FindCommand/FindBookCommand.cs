using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.FindCommand
{
    class FindBookCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public FindBookCommand(BookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            string find="";
            string title;
            string author = "";
            string description;
            string genres = "";
            try
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    find += (parameters[i]+" ");
                }
                
               
            }
            catch
            {
                throw new ArgumentException("Failed parse");
            }

            List<Book> books= this.context.Books.Where(x=>x.Title==find).ToList();
            if (books.Count!=0)
            {
                Book book = books[0];
                 title = book.Title;
                foreach (var item in book.Genres)
                {
                    genres += (item.Name +Environment.NewLine);
                }

                foreach (var item in book.Authors)
                {
                   author+=item.FirstName +" " +item.LastName;
                }
                 description = book.Description;
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
            

            return ($"Title = {title}"+ Environment.NewLine+ $"Genres = {genres}" + $"Author = {author}" + Environment.NewLine +
               $"Description ={description}") ;
        }
    }
}
