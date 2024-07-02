using Domain.Interview.Data.Orders;
using Domain.Interview.Enums;

namespace Domain.Interview.Data.Pizzas
{
    public class Pizza : Entity
    {
        public Pizza() { }
        public Pizza(long id) => Id = id;

        public string? Name { get; set; }
        public byte CrustSize { get; set; }
        public CrustType CrustType { get; set; }

        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; } = new List<PizzaTopping>();
        public virtual ICollection<OrderPizza> OrderPizzas { get; set; } = new List<OrderPizza>();
    }
}
