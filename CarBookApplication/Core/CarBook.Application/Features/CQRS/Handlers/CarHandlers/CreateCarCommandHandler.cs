using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommnad commnad)
        {
            await _repository.CreateAsync(new Car
            {
                BrandId = commnad.BrandId,
                BigImageUrl = commnad.BigImageUrl,
                CoverImageUrl = commnad.CoverImageUrl,
                Fuel = commnad.Fuel,
                Km = commnad.Km,
                Transmission = commnad.Transmission,
                SeatCount = commnad.SeatCount,
                Luggage = commnad.Luggage,
                Model = commnad.Model
            });
        }
    }
}
