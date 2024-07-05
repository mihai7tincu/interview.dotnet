using MediatR;

namespace Domain.Interview.Business.Orders.Queries.GetAll
{
    public class GetAllOrdersQuery : IRequest<List<GetAllOrdersResponse>>
    {
    }
}
