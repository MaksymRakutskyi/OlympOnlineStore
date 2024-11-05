#nullable disable

using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.Models.Models;

public class UserModel
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHHash { get; set; }
    public UserRoleType Role { get; set; }
    public DateTime CreatedAt { get; set; }
}