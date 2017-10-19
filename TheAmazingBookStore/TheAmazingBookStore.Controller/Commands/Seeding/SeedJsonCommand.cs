using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Seeding
{
    class SeedJsonCommand : ICommand
    {
        private readonly IBookStoreContext context;
        public SeedJsonCommand(IBookStoreContext context)
        {
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            this.CountrySeed();
            this.GenreSeed();
            context.SaveChanges();

            this.SellerSeed();
            context.SaveChanges();

            this.BookSeed();
            context.SaveChanges();

            this.AuthorSeed();
            context.SaveChanges();

            return "Json data seeded.";


        }

        private void CountrySeed()
        {
            if (!context.Countries.Any())
            {
                using (StreamReader reader = new StreamReader(@"..\..\..\RawData\countries.json"))
                {
                    string json = reader.ReadToEnd();

                    var countries = JsonConvert.DeserializeObject<List<Country>>(json);

                    foreach (var country in countries)
                    {
                        context.Countries.AddOrUpdate(country);
                    }
                }
            }
        }

        private void GenreSeed()
        {
            if (!context.Genres.Any())
            {
                using (StreamReader reader = new StreamReader(@"..\..\..\RawData\genres.json"))
                {
                    string json = reader.ReadToEnd();

                    var genres = JsonConvert.DeserializeObject<List<Genre>>(json);

                    foreach (var genre in genres)
                    {
                        context.Genres.AddOrUpdate(genre);
                    }
                }
            }
        }

        private void SellerSeed()
        {
            if (!context.Sellers.Any())
            {
                using (StreamReader reader = new StreamReader(@"..\..\..\RawData\sellers.json"))
                {
                    string json = reader.ReadToEnd();
                    dynamic parsed = JObject.Parse(json);
                    foreach (var wrappedSellers in parsed)
                    {
                        foreach (var sellers in wrappedSellers)
                        {
                            foreach (var seller in sellers)
                            {
                                Seller s = new Seller();
                                s.FirstName = seller.firstName;
                                s.LastName = seller.lastName;
                                string countryName = seller.country;
                                Country country = context.Countries.FirstOrDefault(w => w.Name == countryName);
                                s.CountryId = country.Id;
                                s.Country = country;
                                s.Books = new HashSet<Book>();

                                context.Sellers.AddOrUpdate(s);
                            }
                        }
                    }
                }
            }
        }

        private void BookSeed()
        {
            if (!context.Books.Any())
            {
                using (StreamReader reader = new StreamReader(@"..\..\..\RawData\books.json"))
                {
                    string json = reader.ReadToEnd();
                    dynamic parsed = JObject.Parse(json);
                    foreach (var wrappedBooks in parsed)
                    {
                        foreach (var books in wrappedBooks)
                        {
                            foreach (var book in books)
                            {
                                Book b = new Book();
                                b.Title = book.title;
                                b.Authors = new HashSet<Author>();
                                foreach (string genreName in book.genres)
                                {
                                    Genre genre = context.Genres.FirstOrDefault(w => w.Name == genreName);
                                    b.Genres.Add(genre);
                                }

                                b.Description = book.description;
                                b.Rating = book.rating;
                                b.Price = book.price;
                                foreach (string sellerName in book.sellers)
                                {
                                    Seller seller = context.Sellers.FirstOrDefault(w => (w.FirstName + " " + w.LastName) == sellerName);
                                    b.Sellers.Add(seller);
                                }

                                context.Books.AddOrUpdate(b);
                            }
                        }
                    }
                }
            }
        }

        private void AuthorSeed()
        {
            if (!context.Authors.Any())
            {
                using (StreamReader reader = new StreamReader(@"..\..\..\RawData\authors.json"))
                {
                    string json = reader.ReadToEnd();
                    dynamic parsed = JObject.Parse(json);
                    foreach (var wrappedAuthors in parsed)
                    {
                        foreach (var authors in wrappedAuthors)
                        {
                            foreach (var author in authors)
                            {
                                Author a = new Author();
                                a.FirstName = author.firstName;
                                a.LastName = author.lastName;
                                string countryName = author.country;
                                Country country = context.Countries.FirstOrDefault(w => w.Name == countryName);
                                a.CountryId = country.Id;
                                a.Country = country;

                                foreach (string bookTitle in author.books)
                                {
                                    Book book = context.Books.FirstOrDefault(w => w.Title == bookTitle);
                                    a.Books.Add(book);
                                }

                                context.Authors.AddOrUpdate(a);
                            }
                        }
                    }
                }
            }
        }
    }
}
