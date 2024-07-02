using MediatR;

namespace Domain.Interview.Business.Pizzas.Queries.GetAll
{
    public class GetAllPizzaQuery : IRequest<List<GetAllPizzaResponse>>
    {
    }
}
