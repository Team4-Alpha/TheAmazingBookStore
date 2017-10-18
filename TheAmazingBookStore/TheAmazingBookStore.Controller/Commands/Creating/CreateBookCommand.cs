using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Core.Factories;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Creating
{
    public class CreateBookCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public CreateBookCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            string authorName = parameters[0];
            Author author;
            string title;
            double rating;
            string genreName = parameters[3];
            Genre genre;
            string description;
            decimal price;
            string sellerName = parameters[6];
            Seller seller;

            try
            {
                author = context.Authors.FirstOrDefault(a => (a.FirstName + " " + a.LastName) == authorName);
                title = parameters[1];
                rating = double.Parse(parameters[2]);
                genre = context.Genres.FirstOrDefault(g => g.Name == genreName);
                description = parameters[4];
                price =decimal.Parse(parameters[5]);
                seller = context.Sellers.FirstOrDefault(s => (s.FirstName + " " + s.LastName) == sellerName);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBook command parameters.");
            }

            var book = new Book();
            book.Title = title;
            book.Rating = rating;
            book.Description = description;
            book.Price = price;
            book.Authors.Add(author);
            book.Genres.Add(genre);
            book.Sellers.Add(seller);

            this.context.Books.Add(book);
            this.context.SaveChanges();

            return $"Book with Id {this.context.Books.Where(b => b.Title == book.Title).Select(b=>b.Id)} was created.";
        }
    }
}
