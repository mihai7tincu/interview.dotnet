using AutoMapper;
using Domain.Interview.Business.Orders.Commands.Create;
using Microservice.Interview.Controllers.Order.Models;

namespace Microservice.Interview.Controllers.Order
{
    public class OrderMappings : Profile
    {
        public OrderMappings()
        {
            CreateMap<CreateOrderModel, CreateOrderCommand>();
        }
    }
}
