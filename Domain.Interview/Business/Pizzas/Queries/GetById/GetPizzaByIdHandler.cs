using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interview.Business.Pizzas.Queries.GetById
{
    public class GetPizzaByIdHandler : IRequestHandler<GetPizzaByIdQuery, GetPizzaByIdResponse>
    {
        private readonly InterviewDbContext _dbContext;

        public GetPizzaByIdHandler(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetPizzaByIdResponse> Handle(GetPizzaByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pizzas
                .Include(x => x.PizzaToppings)
                .ThenInclude(x => x.Topping)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return entity == null ? null : new GetPizzaByIdResponse
            {
                Name = entity.Name,
                CrustSize = entity.CrustSize,
                CrustType = entity.CrustType.ToString(),
                Toppings = entity.PizzaToppings.Select(x => x.Topping.Name).ToList()
            };
        }
    }
}
