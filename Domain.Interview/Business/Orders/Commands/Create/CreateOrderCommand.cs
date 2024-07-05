using MediatR;

namespace Domain.Interview.Business.Orders.Commands.Create
{
    public class CreateOrderCommand : IRequest<long?>
    {
        public long CustomerId { get; set; }
        public List<long> PizzaIds { get; set; } = new List<long>();
    }
}
