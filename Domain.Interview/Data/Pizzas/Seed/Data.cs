using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interview.Data.Pizzas.Seed
{
    public static class Data
    {
        public static IEnumerable<Pizza> GetPizzas() => new[]
        {
            new Pizza(1) { Name = "Pepperoni", CrustSize = 28, CrustType = "Thin", Toppings = new[] { "Cheese", "Pepperoni" } },
            new Pizza(2) { Name = "Funghi", CrustSize = 32, CrustType = "Normal", Toppings = new[] { "Mushrooms", "Cheese", "Pepperoni" } },
            new Pizza(3) { Name = "Margherita", CrustSize = 40, CrustType = "Thick", Toppings = new[] { "Tomato", "Basil", "Mozzarella" } }
        };
    }
}
