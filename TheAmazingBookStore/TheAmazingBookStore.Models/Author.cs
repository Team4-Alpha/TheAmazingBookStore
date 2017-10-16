using System.Collections.Generic;

namespace TheAmazingBookStore.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public double LastName { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
