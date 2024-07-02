using Domain.Interview.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Interview.Data.Pizzas
{
    public class Pizza : Entity
    {
        public Pizza() { }
        public Pizza(long id) => Id = id;

        public string? Name { get; set; }
        public byte CrustSize { get; set; }
        public CrustType CrustType { get; set; }

        public ICollection<PizzaTopping> PizzaToppings { get; set; } = new List<PizzaTopping>();
    }
}
