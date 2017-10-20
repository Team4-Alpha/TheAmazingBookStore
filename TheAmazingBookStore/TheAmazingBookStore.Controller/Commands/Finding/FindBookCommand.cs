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
    public class FindBookCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public FindBookCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public virtual string Execute(IList<string> parameters)
        {
            int id = int.Parse(parameters[0]);
            string title;
            string authors = "";
            string description;
            string genres = "";
            double rating;
            decimal price;
            string sellers = "";
            Book book = this.context.Books.Find(id);

            title = book.Title;
            foreach (var item in book.Genres)
            {
                genres += (item.Name + "\n");
            }

            foreach (var item in book.Authors)
            {
                authors += item.FirstName + " " + item.LastName + "\n";
            }
            description = book.Description;
            rating = book.Rating;
            price = book.Price;

            foreach (var item in book.Sellers)
            {
                sellers += item.FirstName + " " + item.LastName + "\n";
            }


            var result = $@"Title: {title}
Genres: {genres}
Author: {authors}
Description: {description}
Rating: {rating}
Price: {price}
Sellers: {sellers}";
            return result;
        }
    }
}