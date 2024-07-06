using AutoMapper;
using Domain.Interview.Business.Orders.Commands.Create;
using Domain.Interview.Business.Orders.Queries.GetAll;
using Domain.Interview.configs.RabbitMQ;
using Domain.Interview.Contracts.Orders;
using MassTransit;
using MediatR;
using Microservice.Interview.Controllers.Order.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Microservice.Interview.Controllers.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IRabbitMqService _rabbitMqService;

        public OrderController(
            IMediator mediator,
            IMapper mapper,
            IRabbitMqService rabbitMqService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _rabbitMqService = rabbitMqService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrdersQuery(), cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateOrderModel order, CancellationToken cancellationToken)
        {
            //await _busControl.Publish((IOrderContract)order, cancellationToken); //todo

            var command = _mapper.Map<CreateOrderCommand>(order);
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(CancellationToken cancellationToken)
        {
            var order = new OrderContract
            {
                CustomerId = 1,
                PizzaIds = new List<long> { 1, 2 }
            };
            var orderJson = JsonConvert.SerializeObject(order);

            //using var connection = _rabbitMqService.CreateChannel();
            //using var model = connection.CreateModel();
            //var body = Encoding.UTF8.GetBytes(orderJson);

            //model.BasicPublish("orderExchange",
            //                     string.Empty,
            //                     basicProperties: null,
            //                     body: body);

            //await bus.Publish<OrderContract>(order);

            return Ok(orderJson);
        }
    }
}
