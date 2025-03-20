using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string NameLastname { get; set; }
        public string RefrehToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
    }
}
