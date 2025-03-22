using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pagination;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class CarsController : ApiController
    {

        public CarsController(IMediator mediator) : base(mediator) { }

        //[TypeFilter(typeof(RoleAttribute),Arguments =new Object[] { "Create"})]
        [RoleFilter("Create")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCarCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [RoleFilter("GetAll")]
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(GetAllCarQuery request, CancellationToken cancellationToken)
        {

            PaginationResult<Car> response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }


    }
}
