using Domain.Interview.Data.Pizzas;

namespace Domain.Interview.Data.Toppings
{
    public class Topping : Entity
    {
        public Topping() { }
        public Topping(long id) => Id = id;

        public string? Name { get; set; }

        public ICollection<PizzaTopping> PizzaToppings { get; set; } = new List<PizzaTopping>();
    }
}
