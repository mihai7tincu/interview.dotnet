using Domain.Interview.Enums;

namespace Domain.Interview.Data.Pizzas.Seed
{
    public static class Data
    {
        public static IEnumerable<Pizza> GetPizzas() =>
        [
            new Pizza(1) { Name = "Pepperoni", CrustSize = 28, CrustType = CrustType.Thin },
            new Pizza(2) { Name = "Funghi", CrustSize = 32, CrustType = CrustType.Normal },
            new Pizza(3) { Name = "Margherita", CrustSize = 40, CrustType = CrustType.Thick }
        ];

        public static IEnumerable<PizzaTopping> GetPizzaToppings() =>
        [
            new PizzaTopping(1) { PizzaId = 1, ToppingId = 1 },
            new PizzaTopping(2) { PizzaId = 1, ToppingId = 2 },

            new PizzaTopping(3) { PizzaId = 2, ToppingId = 1 },
            new PizzaTopping(4) { PizzaId = 2, ToppingId = 2 },
            new PizzaTopping(5) { PizzaId = 2, ToppingId = 3 },

            new PizzaTopping(6) { PizzaId = 3, ToppingId = 4 },
            new PizzaTopping(7) { PizzaId = 3, ToppingId = 5 },
            new PizzaTopping(8) { PizzaId = 3, ToppingId = 6 },
        ];
    }
}
