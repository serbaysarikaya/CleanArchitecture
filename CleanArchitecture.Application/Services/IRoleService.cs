using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Services
{
   public interface IRoleService
    {
        Task CreateAsync(CreateRoleCommand request);
    }
}
