using Domain.Interview.Data.Pizzas;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interview.Business.Pizzas.Commands.Upsert
{
    public class UpsertPizzaHandler : IRequestHandler<UpsertPizzaCommand, long?>
    {
        private readonly InterviewDbContext _dbContext;

        public UpsertPizzaHandler(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long?> Handle(UpsertPizzaCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                //insert
                var entity = new Pizza
                {
                    Name = request.Name,
                    CrustSize = request.CrustSize,
                    CrustType = request.CrustType
                };

                entity.PizzaToppings = request.Toppings.Select(x => new PizzaTopping
                {
                    Pizza = entity,
                    ToppingId = x
                }).ToList();

                await _dbContext.Pizzas.AddAsync(entity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
            else
            {
                //update
                var entity = await _dbContext.Pizzas
                    .Include(x => x.PizzaToppings)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (entity == null)
                    return null;

                entity.Name = request.Name;
                entity.CrustSize = request.CrustSize;
                entity.CrustType = request.CrustType;

                var toppingsToDelete = entity.PizzaToppings;

                entity.PizzaToppings = request.Toppings.Select(x => new PizzaTopping
                {
                    PizzaId = entity.Id,
                    Pizza = entity,
                    ToppingId = x
                }).ToList();

                _dbContext.PizzaToppings.RemoveRange(toppingsToDelete);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
