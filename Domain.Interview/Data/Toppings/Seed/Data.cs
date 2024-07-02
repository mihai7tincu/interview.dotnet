namespace Domain.Interview.Data.Toppings.Seed
{
    public static class Data
    {
        public static IEnumerable<Topping> GetToppings() =>
        [
            new Topping(1) { Name = "Cheese" },
            new Topping(2) { Name = "Pepperoni" },
            new Topping(3) { Name = "Mushrooms" },
            new Topping(4) { Name = "Tomato" },
            new Topping(5) { Name = "Basil" },
            new Topping(6) { Name = "Mozzarella" },
            new Topping(7) { Name = "Chorizo" },
            new Topping(8) { Name = "Jalapeno" }
        ];
    }
}
