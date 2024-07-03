﻿using MediatR;

namespace Domain.Interview.Business.Pizzas.Commands.Delete
{
    public class DeletePizzaByIdCommand : IRequest<long?>
    {
        public long Id { get; set; }
    }
}