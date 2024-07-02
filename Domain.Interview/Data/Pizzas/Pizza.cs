using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Interview.Data.Pizzas
{
    public class Pizza : Entity
    {
        public string? Name { get; set; }
        public byte CrustSize { get; set; }
        public string? CrustType { get; set; }

        [NotMapped]
        public string[] Toppings { get; set; } = new string[0];

        public Pizza() { }
        public Pizza(long id) => Id = id;
    }
}
