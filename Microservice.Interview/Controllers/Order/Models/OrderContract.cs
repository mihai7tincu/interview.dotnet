using Domain.Interview.Contracts.Orders;

namespace Microservice.Interview.Controllers.Order.Models
{
    public class OrderContract : IOrderContract
    {
        public long CustomerId { get; set; }
        public List<long> PizzaIds { get; set; } = new List<long>();
    }
}
