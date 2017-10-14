using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAmazingBookStore.Models
{
   public class Seller
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Rating { get; set; }

        public ICollection<Country> Countries { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
