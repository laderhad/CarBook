﻿using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler:IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceID);
            value.Title = request.Title;
            value.Description = request.Description;
            value.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(value);

        }
    }
}
