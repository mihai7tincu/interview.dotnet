using Domain.Interview.Enums;

namespace Microservice.Interview.Controllers.Pizza.Models
{
    public class UpsertPizzaModel
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public byte CrustSize { get; set; }
        public CrustType CrustType { get; set; }
        public ICollection<long> Toppings { get; set; } = new List<long>();
    }
}
