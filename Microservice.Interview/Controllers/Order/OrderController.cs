using AutoMapper;
using Domain.Interview.Business.Orders.Commands.Create;
using Domain.Interview.Business.Orders.Queries.GetAll;
using Domain.Interview.Business.Orders.Queries.GetStatistics;
using MediatR;
using Microservice.Interview.configs.MassTransit;
using Microservice.Interview.Controllers.Order.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Interview.Controllers.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IMassTransitBusService _busService;

        public OrderController(
            IMediator mediator,
            IMapper mapper,
            IMassTransitBusService busService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _busService = busService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrdersQuery(), cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateOrderModel order, CancellationToken cancellationToken)
        {
            await _busService.Publish(order);
            var command = _mapper.Map<CreateOrderCommand>(order);
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost("publish")]
        public async Task<IActionResult> Test(CancellationToken cancellationToken)
        {
            var order = new OrderContract
            {
                CustomerId = 1,
                PizzaIds = new List<long> { 1, 2 }
            };

            await _busService.Publish(order);
            return Ok(order);
        }
        
        [HttpGet("get-stats")]
        public async Task<IActionResult> GetStats(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetOrderStatisticsQuery(), cancellationToken));
        }
    }
}
