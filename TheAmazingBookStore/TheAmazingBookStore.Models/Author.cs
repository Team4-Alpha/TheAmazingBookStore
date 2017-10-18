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
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public int CountryId { get; set; }
        
        public virtual Country Country { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
    }
}
