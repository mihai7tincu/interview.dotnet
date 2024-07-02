using Domain.Interview.Enums;
using MediatR;

namespace Domain.Interview.Business.Pizzas.Commands.Upsert
{
    public class UpsertPizzaCommand : IRequest<long?>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public byte CrustSize { get; set; }
        public CrustType CrustType { get; set; }
        public ICollection<long> Toppings { get; set; } = new List<long>();
    }
}
