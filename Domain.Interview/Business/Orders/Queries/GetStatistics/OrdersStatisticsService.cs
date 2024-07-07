using Microsoft.EntityFrameworkCore;

namespace Domain.Interview.Business.Orders.Queries.GetStatistics
{
    public class OrdersStatisticsService : IOrdersStatisticsService
    {
        private readonly InterviewDbContext _dbContext;

        public OrdersStatisticsService(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetOrderStatisticsResponse> GetOrdersStatisticsAsync(DateTimeOffset refDate, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.Orders
                .Include(x => x.OrderPizzas)
                .ThenInclude(x => x.Pizza)
                .ThenInclude(x => x.PizzaToppings)
                .ThenInclude(x => x.Topping)
                .ToListAsync(cancellationToken);

            var groupByPizza = await _dbContext.OrderPizzas.Where(x => x.Order.Timestamp <= refDate)
                .Select(x => x.Pizza)
                .GroupBy(x => x.Id)
                .ToListAsync(cancellationToken); ;

            var topPizza = groupByPizza
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();
                

            return new GetOrderStatisticsResponse
            {
                TopPizzaName = topPizza.FirstOrDefault()?.Name,
                TopPizzaCount = topPizza.Count()
                //TopToppingNam
                //TopToppingCou
                //TopCrustSize
                //TopCrustType
            };
        }
    }
}
