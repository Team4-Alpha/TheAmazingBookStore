using System.Collections.Generic;

namespace TheAmazingBookStore.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public double LastName { get; set; }

        public ICollection<Country> Countries { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
