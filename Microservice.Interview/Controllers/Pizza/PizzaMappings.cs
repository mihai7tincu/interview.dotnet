using AutoMapper;
using Domain.Interview.Business.Pizzas.Commands.Upsert;
using Microservice.Interview.Controllers.Pizza.Models;

namespace Microservice.Interview.Controllers.Pizza
{
    public class PizzaMappings : Profile
    {
        public PizzaMappings()
        {
            CreateMap<UpsertPizzaModel, UpsertPizzaCommand>();
        }
    }
}
