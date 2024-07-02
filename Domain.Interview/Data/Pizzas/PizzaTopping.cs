using Domain.Interview.Data.Toppings;

namespace Domain.Interview.Data.Pizzas
{

    public class PizzaTopping : Entity
    {
        public PizzaTopping() { }
        public PizzaTopping(long id) => Id = id;

        public long PizzaId { get; set; }
        public virtual Pizza? Pizza { get; set; }

        public long ToppingId { get; set; }
        public virtual Topping? Topping { get; set; }
    }
}
