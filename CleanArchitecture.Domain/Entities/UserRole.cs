using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
   public sealed class UserRole:Entity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }

    }
}
