﻿using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole
{
    class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, MessageResponse>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.CreateAsync(request);
            return new("Role Kayıdı basrıyla yapıldı.");
        }
    }
}
