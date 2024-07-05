using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interview.Business.Orders.Queries.GetAll
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<GetAllOrdersResponse>>
    {
        private readonly InterviewDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllOrdersHandler(
            InterviewDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GetAllOrdersResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Orders
                .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.Pizza)
                .Include(x => x.Customer)
                .ToListAsync(cancellationToken);

            var result = _mapper.Map<List<GetAllOrdersResponse>>(entities);
            return result;
        }
    }
}
