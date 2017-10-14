using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() 
            :base("name=BookStore")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Seller> Sellers { get; set; }
    }
}
