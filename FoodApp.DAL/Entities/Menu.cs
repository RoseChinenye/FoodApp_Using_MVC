﻿
namespace FoodApp.DAL.Entities
{
    public class Menu : BaseEntity
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        
    }
}
