using FoodApp.DAL.Entities;

namespace FoodApp.BLL.Models
{
    public class DeleteVM : BaseEntity
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
    }
}
