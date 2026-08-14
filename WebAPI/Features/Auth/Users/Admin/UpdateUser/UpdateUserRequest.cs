using WebAPI.Features.Auth.Entities;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Auth.Users.Admin.UpdateUser;

public class UpdateUserRequest
{
    [RouteParam]
    public int Id { get; set; }
    
    public string FullName { get; set; } = null!;
    
    public string PhoneNumber { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }
    
    public User ToEntity() => new User()
    {
        FullName = FullName,
        PhoneNumber = PhoneNumber,
        Email = Email,
        Password = Password,
        IsAdmin = IsAdmin
    };
}