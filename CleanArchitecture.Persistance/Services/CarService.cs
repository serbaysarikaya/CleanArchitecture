using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistance.Services
{
 public   class CarService(AppDbContext context) : ICarService
    {
        private readonly AppDbContext _context = context;

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = new Car
            {
                Name = request.Name,
                Model = request.Model,
                EnginePower = request.EnginePower
            };

            await _context.Set<Car>().AddAsync(car, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
