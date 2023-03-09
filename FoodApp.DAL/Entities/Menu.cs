using FoodApp.DAL.Enums;

namespace FoodApp.DAL.Entities
{
    public class Menu : BaseEntity
    {
        public FoodCategory Category { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int AdminId { get; set; }


        public Admin admin { get; set; }
    }
}
