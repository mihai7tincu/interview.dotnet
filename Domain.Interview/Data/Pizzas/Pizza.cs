namespace Domain.Interview.Data.Pizzas
{
    public class Pizza //: Entity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public byte CrustSize { get; set; }
        public string? CrustType { get; set; }
        public string[] Toppings { get; set; } = new string[0];
    }
}
