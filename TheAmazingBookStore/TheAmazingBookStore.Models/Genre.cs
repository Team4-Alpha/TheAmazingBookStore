using System.ComponentModel.DataAnnotations;

namespace TheAmazingBookStore.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "The genre's name cannot be less than 2 or more than 25 symbols long.")]
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}
