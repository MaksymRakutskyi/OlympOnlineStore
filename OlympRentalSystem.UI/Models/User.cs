using OlympRentalSystem.Shared.Enums;

namespace OlympRentalSystem.UI.Models;

public class User
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRoleType Role { get; set; }
    public DateTime CreatedAt { get; set; }
}