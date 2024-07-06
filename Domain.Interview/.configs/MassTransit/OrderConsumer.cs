using Azure;
using Domain.Interview.Data.Orders;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interview.configs.MassTransit
{
    public class OrderConsumer : IConsumer<Order>
    {
        private readonly InterviewDbContext _dbContext;

        public OrderConsumer(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<Order> context)
        {
            var msg = context.Message;
            Console.WriteLine(msg);

            await _dbContext.Orders.AddAsync(msg, context.CancellationToken);
            await _dbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}
