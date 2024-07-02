using MediatR;

namespace Domain.Interview.Business.Pizzas.Queries.GetById
{
    public class GetPizzaByIdQuery : IRequest<GetPizzaByIdResponse>
    {
        public long Id { get; set; }

        public GetPizzaByIdQuery() { }
        public GetPizzaByIdQuery(long id) => Id = id;
    }
}
