using AutoMapper;
using Domain.Interview.Data.Orders;
using MediatR;

namespace Domain.Interview.Business.Orders.Commands.Create
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, long?>
    {
        private readonly InterviewDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateOrderHandler(
            InterviewDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<long?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = new Order
            {
                Timestamp = DateTimeOffset.UtcNow,
                CustomerId = request.CustomerId
            };

            entity.OrderPizzas = request.PizzaIds.Select(x => new OrderPizza
            {
                Order = entity,
                PizzaId = x
            }).ToList();

            await _dbContext.Orders.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
