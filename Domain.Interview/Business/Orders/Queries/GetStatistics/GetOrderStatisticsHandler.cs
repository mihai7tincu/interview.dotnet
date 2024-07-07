using AutoMapper;
using MediatR;

namespace Domain.Interview.Business.Orders.Queries.GetStatistics
{
    public class GetOrderStatisticsHandler : IRequestHandler<GetOrderStatisticsQuery, GetOrderStatisticsResponse>
    {
        private readonly InterviewDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IOrdersStatisticsService _ordersStatisticsService;

        public GetOrderStatisticsHandler(
            InterviewDbContext dbContext,
            IMapper mapper,
            IOrdersStatisticsService ordersStatisticsService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _ordersStatisticsService = ordersStatisticsService;
        }

        public async Task<GetOrderStatisticsResponse> Handle(GetOrderStatisticsQuery request, CancellationToken cancellationToken)
        {
            var result = await _ordersStatisticsService.GetOrdersStatisticsAsync(DateTimeOffset.UtcNow, cancellationToken);
            return result;
        }
    }
}
