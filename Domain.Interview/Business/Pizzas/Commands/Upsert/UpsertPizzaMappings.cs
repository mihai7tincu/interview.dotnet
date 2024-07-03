using AutoMapper;
using Domain.Interview.Data.Pizzas;

namespace Domain.Interview.Business.Pizzas.Commands.Upsert
{
    public class UpsertPizzaMappings : Profile
    {
        public UpsertPizzaMappings()
        {
            CreateMap<UpsertPizzaCommand, Pizza>();
        }
    }
}
