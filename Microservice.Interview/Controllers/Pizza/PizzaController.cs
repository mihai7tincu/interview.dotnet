using AutoMapper;
using Domain.Interview;
using Domain.Interview.Business.Pizzas.Commands.Upsert;
using Domain.Interview.Business.Pizzas.Queries.GetAll;
using Domain.Interview.Business.Pizzas.Queries.GetById;
using MediatR;
using Microservice.Interview.Controllers.Pizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Interview.Controllers.Pizza
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly InterviewDbContext _dbContext;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PizzaController(
            ILogger<PizzaController> logger,
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
            return Ok(await _mediator.Send(new GetAllPizzaQuery(), cancellationToken));
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get([FromRoute] long id, CancellationToken cancellationToken)
        {
            var query = new GetPizzaByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UpsertPizza pizza, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpsertPizzaCommand>(pizza);
            var result = await _mediator.Send(command, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpsertPizza pizza, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpsertPizzaCommand>(pizza);

            var result = await _mediator.Send(command, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity == null)
                return NotFound();

            _dbContext.Pizzas.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok(id);
        }
    }
}
