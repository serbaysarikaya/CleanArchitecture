using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities
{
  public sealed  class Role:IdentityRole
    {
        public Role()
        {
            Id=Guid.NewGuid().ToString();
        }
    }
}
