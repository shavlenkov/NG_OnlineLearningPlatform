using AuthService.DAL.Enums;

namespace AuthService.DAL.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public string? AvatarURL { get; set; }
    public Role Role { get; set; } = Role.Student;
}