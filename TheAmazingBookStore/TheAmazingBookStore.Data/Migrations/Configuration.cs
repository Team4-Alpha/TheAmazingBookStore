using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<BookStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BookStoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            using (StreamReader r = new StreamReader(@"c:\users\iliyadamyanov\documents\programming\telerik-academy-alpha\databases\sql\team-project\theamazingbookstore\rawdata\genres.json"))
            {
                string json = r.ReadToEnd();
                List<Genre> genreslist = JsonConvert.DeserializeObject<List<Genre>>(json);
                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(genreslist);
                    context.SaveChanges();
                }
            }



            //using (StreamReader r = new StreamReader(@"C:\Users\IliyaDamyanov\Documents\Programming\Telerik-Academy-Alpha\Databases\SQL\Team-project\TheAmazingBookStore\RawData\books.json"))
            //{
            //    string json = r.ReadToEnd();
            //    List<Book> booksList = JsonConvert.DeserializeObject<List<Book>>(json);
            //    if (!context.Books.Any())
            //    {
            //        context.Books.AddRange(booksList);
            //    }
            //}

            using (StreamReader r = new StreamReader(@"C:\Users\IliyaDamyanov\Documents\Programming\Telerik-Academy-Alpha\Databases\SQL\Team-project\TheAmazingBookStore\RawData\sellers.json"))
            {
                string json = r.ReadToEnd();
                List<Seller> sellersList = JsonConvert.DeserializeObject<List<Seller>>(json);
                if (!context.Sellers.Any())
                {
                    foreach (var item in sellersList)
                    {
                        var customeSeller = new Seller { FirstName = item.FirstName, LastName = item.LastName, Country = context.Countries.Where(w => w.Name.Equals(item.Country)).Single(), Books = new HashSet<Book>() };
                        context.Sellers.Add(customeSeller);
                    }
                }
            }


            context.SaveChanges();
        }
    }
}
