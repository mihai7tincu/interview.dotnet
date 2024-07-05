using AutoMapper;
using Domain.Interview.Data.Orders;

namespace Domain.Interview.Business.Orders.Queries.GetAll
{
    public class GetAllOrdersMappings : Profile
    {
        public GetAllOrdersMappings()
        {
            CreateMap<Order, GetAllOrdersResponse>()
                .ForMember(d => d.CustomerAddress, o => o.MapFrom(s => s.Customer != null ? s.Customer.Address : string.Empty))
                .ForMember(d => d.CustomerPhone, o => o.MapFrom(s => s.Customer != null ? s.Customer.Phone : string.Empty))
                .ForMember(d => d.PizzaList, o => o.MapFrom(s => s.OrderPizzas.Select(x => x.Pizza != null ? x.Pizza.Name : string.Empty).ToList()));
        }
    }
}
