using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheAmazingBookStore.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "The FirstName's length cannot be less than 2 or more than 25 symbols long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "The LastName's length cannot be less than 2 or more than 25 symbols long.")]
        public string LastName { get; set; }

        public int CountryId { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        [Required]
        public virtual ICollection<Book> Books { get; set; }
    }
}
