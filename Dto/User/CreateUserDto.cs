using blogfolio.ENUMS;
using System.ComponentModel.DataAnnotations;

namespace blogfolio.Dto.User
{
    public record class CreateUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Reader;
    }
}

