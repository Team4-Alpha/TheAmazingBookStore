using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheAmazingBookStore.Models
{
    public class Book
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Genres = new HashSet<Genre>();
            this.Sellers = new HashSet<Seller>();
        }

        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "The book's title cannot be less than 2 or more than 75 symbols long.")]
        public string Title { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        
        public virtual ICollection<Genre> Genres { get; set; }
        
        public string Description { get; set; }
        
        public double Rating { get; set; }
        
        public decimal Price { get; set; }
        
        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
