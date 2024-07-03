using MediatR;

namespace Domain.Interview.Business.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<List<GetAllOrdersResponse>>
    {
    }
}
