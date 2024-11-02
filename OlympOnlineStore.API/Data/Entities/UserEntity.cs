﻿#nullable disable
using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.API.Data.Entities;

public class UserEntity
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public UserRoleType Role { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<BookingEntity> BookingEntities { get; set; }
}