using System.Data.Entity;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Data.Abstractions
{
    public interface IBookStoreContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Seller> Sellers { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Country> Countries { get; set; }

        int SaveChanges();
    }
}
