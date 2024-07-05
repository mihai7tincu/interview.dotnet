using System.Runtime.CompilerServices;

namespace Domain.Interview.Contracts.Orders
{
    public interface IOrderContract
    {
        long CustomerId { get; set; }
        List<long> PizzaIds { get; set; }
    }
}
