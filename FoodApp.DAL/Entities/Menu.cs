using System.ComponentModel.DataAnnotations;

namespace FoodApp.DAL.Entities
{
    public class Menu : BaseEntity
    {
        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string Picture { get; set; } 

        

    }
}
