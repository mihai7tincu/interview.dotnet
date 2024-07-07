namespace Domain.Interview.Business.Orders.Queries.GetStatistics
{
    public class GetOrderStatisticsResponse
    {
        public string? TopPizzaName { get; set; }
        public int TopPizzaCount { get; set; }

        public string? TopToppingName { get; set; }
        public string? TopToppingCount { get; set; }

        public string? TopCrustSize { get; set; }
        public string? TopCrustType { get; set; }
    }
}
