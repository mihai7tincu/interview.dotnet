﻿using Domain.Interview;
using Microservice.Interview.Controllers.Pizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Interview.Controllers.Pizza
{
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly InterviewDbContext _dbContext;

        public PizzaController(
            ILogger<PizzaController> logger,
            InterviewDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _dbContext.Pizzas
                .ToListAsync(cancellationToken);

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get([FromRoute] long id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return entity != null ? Ok(entity) : NotFound();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UpsertPizza pizza, CancellationToken cancellationToken)
        {
            var entity = new Domain.Interview.Data.Pizzas.Pizza
            {
                Name = pizza.Name,
                CrustSize = pizza.CrustSize,
                CrustType = pizza.CrustType
            };

            await _dbContext.Pizzas.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok(entity.Id);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpsertPizza pizza, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity == null) 
                return NotFound();

            entity.Name = pizza.Name;
            entity.CrustSize = pizza.CrustSize;
            entity.CrustType = pizza.CrustType;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok(entity);
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
