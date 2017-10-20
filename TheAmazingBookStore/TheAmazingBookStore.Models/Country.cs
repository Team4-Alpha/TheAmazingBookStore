using System.ComponentModel.DataAnnotations;

namespace TheAmazingBookStore.Models
{
    public class Country
    {
        public int Id { get; set; }
        
        [StringLength(25,MinimumLength =2,ErrorMessage = "The name of the country cannot be less than 2 or more than 25 symbols long.")]
        public string Name { get; set; }
    }
}
