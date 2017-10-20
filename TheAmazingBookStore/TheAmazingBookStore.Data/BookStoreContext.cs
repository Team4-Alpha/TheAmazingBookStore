using System.Data.Entity;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany<Author>(s => s.Authors)
                .WithMany(c => c.Books)
                .Map(cs =>
                {
                    cs.MapLeftKey("BookRefId");
                    cs.MapRightKey("AuthorRefId");
                    cs.ToTable("BookAuthor");
                });

            modelBuilder.Entity<Book>()
                .HasMany<Seller>(s => s.Sellers)
                .WithMany(c => c.Books)
                .Map(cs =>
                {
                    cs.MapLeftKey("BookRefId");
                    cs.MapRightKey("SellerRefId");
                    cs.ToTable("BookSeller");
                });
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}
