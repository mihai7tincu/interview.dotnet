namespace Domain.Interview.Data.Pizzas
{

    public class PizzaTopping : Entity
    {
        public PizzaTopping() { }
        public PizzaTopping(long id) => Id = id;

        public long PizzaId { get; set; }
        public long ToppingId { get; set; }
    }
}
