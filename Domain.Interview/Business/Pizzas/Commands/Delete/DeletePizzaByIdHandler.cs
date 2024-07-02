using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interview.Business.Pizzas.Commands.Delete
{
    public class DeletePizzaByIdHandler : IRequestHandler<DeletePizzaByIdCommand, long?>
    {
        private readonly InterviewDbContext _dbContext;

        public DeletePizzaByIdHandler(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long?> Handle(DeletePizzaByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pizzas
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return null;

            _dbContext.Pizzas.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
