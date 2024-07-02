using Microsoft.AspNetCore.Mvc;
using Domain.Interview.Data.Pizzas;
using Domain.Interview;
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
        public async Task<IActionResult> GetAll()
        {
            var record = await _dbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == 1);
            record.Name += " Promotion";

            var result = new List<Domain.Interview.Data.Pizzas.Pizza>
            {
                new Domain.Interview.Data.Pizzas.Pizza
                {
                    Id = 1,
                    Name = "Pepperoni",
                    CrustSize = 28,
                    CrustType = "Thin",
                    Toppings = new[] { "Cheese", "Pepperoni"}
                },
                new Domain.Interview.Data.Pizzas.Pizza
                {
                    Id = 2,
                    Name = "Funghi",
                    CrustSize = 32,
                    CrustType = "Normal",
                    Toppings = new[] { "Mushrooms", "Cheese", "Pepperoni"}
                },
                new Domain.Interview.Data.Pizzas.Pizza
                {
                    Id = 3,
                    Name = "Margherita",
                    CrustSize = 40,
                    CrustType = "Thick",
                    Toppings = new[] { "Tomato", "Basil", "Mozzarella" }
                }
            };

            return await Task.FromResult(Ok(result));
        }
    }
}
