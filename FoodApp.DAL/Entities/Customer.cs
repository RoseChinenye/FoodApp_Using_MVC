using System.Collections.Generic;

namespace FoodApp.DAL.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public IEnumerable<Order> Orders { get; set; } 
        public IEnumerable<Menu> Menu { get; set; }
    }
}
