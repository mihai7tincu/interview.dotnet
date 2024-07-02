using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interview.Business.Pizzas.Queries.GetAll
{
    public class GetAllPizzaHandler : IRequestHandler<GetAllPizzaQuery, List<GetAllPizzaResponse>>
    {
        private readonly InterviewDbContext _dbContext;

        public GetAllPizzaHandler(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetAllPizzaResponse>> Handle(GetAllPizzaQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Pizzas
                .Include(x => x.PizzaToppings)
                .ThenInclude(x => x.Topping)
                .ToListAsync(cancellationToken);

            return entities.Select(x => new GetAllPizzaResponse
            {
                Name = x.Name,
                CrustSize = x.CrustSize,
                CrustType = x.CrustType.ToString(),
                Toppings = x.PizzaToppings.Select(y => y.Topping.Name).ToList()
            }).ToList();
        }
    }
}
