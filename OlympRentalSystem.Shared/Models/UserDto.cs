using OlympRentalSystem.Shared.Enums;

namespace OlympRentalSystem.Shared.Models;

public class UserDto
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Password { get; set; }
    public UserRoleType Role { get; set; }
    public DateTime CreatedAt { get; set; }
}