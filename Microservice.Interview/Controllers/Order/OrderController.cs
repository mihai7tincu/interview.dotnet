using AutoMapper;
using Domain.Interview;
using Domain.Interview.Business.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Interview.Controllers.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly InterviewDbContext _dbContext;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(
            ILogger<OrderController> logger,
            InterviewDbContext dbContext,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrdersQuery(), cancellationToken));
        }
    }
}
