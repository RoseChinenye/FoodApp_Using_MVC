using FoodApp.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace FoodApp.BLL.Models
{
    public class MenuVM 
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }

    }
}
