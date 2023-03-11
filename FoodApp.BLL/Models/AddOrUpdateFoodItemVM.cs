using FoodApp.DAL.Enums;

namespace FoodApp.BLL.Models
{
    public class AddOrUpdateFoodItemVM
    {
        public FoodCategory Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }

    }
}
