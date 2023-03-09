using System.Collections.Generic;

namespace FoodApp.DAL.Entities
{
    public class Admin : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<Menu> Menu { get; set; } 
        public IEnumerable<Order> Orders { get; set; }
    }
}
