namespace Domain.Interview.Business.Pizzas.Queries.GetAll
{
    public class GetAllPizzaResponse
    {
        public string? Name { get; set; }
        public byte CrustSize { get; set; }
        public string? CrustType { get; set; }
        public ICollection<string> Toppings { get; set; } = new List<string>();
    }
}
