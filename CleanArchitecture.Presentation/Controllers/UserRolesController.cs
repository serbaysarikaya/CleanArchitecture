﻿using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class UserRolesController : ApiController
    {
        public UserRolesController(IMediator mediator) : base(mediator)
        {
           
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }
    }
}
