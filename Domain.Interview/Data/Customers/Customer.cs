using Domain.Interview.Data.Orders;

namespace Domain.Interview.Data.Customers
{
    public class Customer : Entity
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
