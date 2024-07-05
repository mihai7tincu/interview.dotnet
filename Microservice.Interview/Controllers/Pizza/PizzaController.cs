using AutoMapper;
using Domain.Interview.Business.Pizzas.Commands.Delete;
using Domain.Interview.Business.Pizzas.Commands.Upsert;
using Domain.Interview.Business.Pizzas.Queries.GetAll;
using Domain.Interview.Business.Pizzas.Queries.GetById;
using MediatR;
using Microservice.Interview.Controllers.Pizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Interview.Controllers.Pizza
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PizzaController(
            ILogger<PizzaController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
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
        public async Task<IActionResult> Create([FromBody] UpsertPizzaModel pizza, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpsertPizzaCommand>(pizza);
            var result = await _mediator.Send(command, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpsertPizzaModel pizza, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpsertPizzaCommand>(pizza);
            var result = await _mediator.Send(command, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            var command = new DeletePizzaByIdCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
