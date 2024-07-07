using Domain.Interview.Data.Orders;

namespace Domain.Interview.Business.Orders.Queries.GetStatistics
{
    public interface IOrdersStatisticsService
    {
        Task<GetOrderStatisticsResponse> GetOrdersStatisticsAsync(DateTimeOffset refDate, CancellationToken cancellationToken);
    }
}
