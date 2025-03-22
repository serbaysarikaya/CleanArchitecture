using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistance.Repositories
{
    public sealed class UserRoleRepository : Repository<UserRole, AppDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
