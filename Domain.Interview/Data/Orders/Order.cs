using Domain.Interview.Data.Customers;

namespace Domain.Interview.Data.Orders
{
    public class Order : Entity
    {
        public DateTimeOffset Timestamp { get; set; }
        public long CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderPizza> OrderPizzas { get; set; } = new List<OrderPizza>();
    }
}
