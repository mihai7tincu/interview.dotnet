using Domain.Interview.Enums;

namespace Microservice.Interview.Controllers.Pizza.Models
{
    public class UpsertPizza
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public byte CrustSize { get; set; }
        public CrustType CrustType { get; set; }
    }
}
