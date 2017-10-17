using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Migrations;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreContext, Configuration>());

            //using (StreamReader r = new StreamReader(@"C:\Users\IliyaDamyanov\Documents\Programming\Telerik-Academy-Alpha\Databases\SQL\Team-project\TheAmazingBookStore\RawData\authors.json"))
            //{
            //    string json = r.ReadToEnd();
            //    //var anonymousAuthor = new {}
            //    List<Author> authorsList = JsonConvert.DeserializeObject<List<Author>>(json);
            //    //if (!context.Authors.Any())
            //    //{
            //    //    //foreach (var singleAuthor in authorsList)
            //    //    //{
            //    //    //    Author author = new Author() { FirstName = singleAuthor.FirstName, LastName = singleAuthor.LastName, }
            //    //    //}
            //    //}
            //}
            using (var context = new BookStoreContext())
            {
                using (StreamReader r = new StreamReader(@"C:\Users\IliyaDamyanov\Documents\Programming\Telerik-Academy-Alpha\Databases\SQL\Team-project\TheAmazingBookStore\RawData\sellers.json"))
                {
                    string json = r.ReadToEnd();

                    var definition = new List<Seller>();// { FirstName = "", LastName = "",CountryId = 0, Country = new Country(), Books = new HashSet<Book>() };

                    List<Seller> sellersList = JsonConvert.DeserializeAnonymousType<List<Seller>>(json, definition);
                    if (!context.Sellers.Any())
                    {
                        foreach (var item in sellersList)
                        {
                            var customeSeller = new Seller { FirstName = item.FirstName, LastName = item.LastName, CountryId = context.Countries.Where(w => w.Name.Equals(item.Country)).Select(w => w.Id).Single(), Books = new HashSet<Book>() };
                            context.Sellers.Add(customeSeller);
                        }
                    }
                }
            }
            
        }
    }
}
