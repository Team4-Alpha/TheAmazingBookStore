using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Data
{
    public class BookStoreContext : DbContext, IBookStoreContext
    {
        public BookStoreContext() 
            :base("name=BookStore")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}
