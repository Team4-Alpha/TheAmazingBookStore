using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.FindCommand
{
    public class FindBookCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public FindBookCommand(BookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public virtual string Execute(IList<string> parameters)
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

            Book book= this.context.Books.FirstOrDefault(x=>x.Title==find);
            if (book != null)
            {
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
            
            var result= ($"Title = {title}" + Environment.NewLine + $"Genres = {genres}" + $"Author = {author}" + Environment.NewLine +
               $"Description ={description}") ;
            return result;
        }
    }
}
