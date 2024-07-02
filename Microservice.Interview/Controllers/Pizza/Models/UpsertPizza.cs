namespace Microservice.Interview.Controllers.Pizza.Models
{
    public class UpsertPizza
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public byte CrustSize { get; set; }
        public string? CrustType { get; set; }
    }
}
