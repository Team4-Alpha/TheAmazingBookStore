using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheAmazingBookStore.Models
{
    public class Seller
    {
        public Seller()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [StringLength(25, MinimumLength = 2, ErrorMessage = "The first name of the seller cannot be less than 2 or more than 25 symbols long.")]
        public string FirstName { get; set; }

        [StringLength(25, MinimumLength = 2, ErrorMessage = "The last name of the seller cannot be less than 2 or more than 25 symbols long.")]
        public string LastName { get; set; }

        public int? CountryId { get; set; }
        
        public virtual Country Country { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
    }
}
