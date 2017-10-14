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

        public double LastName { get; set; }

        public ICollection<Country> Countries { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
