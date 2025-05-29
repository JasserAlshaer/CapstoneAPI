using System;
using System.Collections.Generic;

namespace CapstoneAPI.Entities;

public  class Client : MainEntity
{
    public string? Image { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public int? CountryCodeId { get; set; }
    public string? OTPCode { get; set; }
    public DateTime? OTPExipry { get; set; }
    public bool? IsLoggedIn { get; set; } = false;
    public DateTime? LastLoginTime { get; set; }
    public bool? IsVerfied { get; set; }
    public int? RoleId { get; set; }

}
