namespace Domain.Interview.Business.Orders.Queries.GetAll
{
    public class GetAllOrdersResponse
    {
        public DateTimeOffset Timestamp { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerPhone { get; set; }
        public List<string> PizzaList { get; set; } = new List<string>();
    }
}
