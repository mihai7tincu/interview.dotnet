using AutoMapper;
using Domain.Interview.Data.Pizzas;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interview.Business.Pizzas.Commands.Upsert
{
    public class UpsertPizzaHandler : IRequestHandler<UpsertPizzaCommand, long?>
    {
        private readonly InterviewDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpsertPizzaHandler(
            InterviewDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<long?> Handle(UpsertPizzaCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                //insert
                var entity = _mapper.Map<Pizza>(request);

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
