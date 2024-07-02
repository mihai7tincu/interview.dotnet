namespace Domain.Interview.Data.Toppings
{
    public class Topping : Entity
    {
        public string? Name { get; set; }

        public Topping() { }
        public Topping(long id) => Id = id;
    }
}
