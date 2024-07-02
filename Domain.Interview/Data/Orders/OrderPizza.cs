using Domain.Interview.Data.Pizzas;

namespace Domain.Interview.Data.Orders
{
    public class OrderPizza : Entity
    {
        public long OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public long PizzaId { get; set; }
        public virtual Pizza? Pizza { get; set; }
    }
}
