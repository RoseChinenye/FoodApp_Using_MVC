using System;

namespace FoodApp.DAL.Entities
{
    public class Order : BaseEntity
    {
        public DateTime TimeOrdered { get; set; }
        public bool IsDelivered { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
