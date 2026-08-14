using WebAPI.Features.Auth.Entities;
using WebAPI.Features.Common.PhoneNumbers.Admin.UpdatePhoneNumber;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Auth.Users.Admin.UpdateUser;

public class UpdateUserResponse
{
    public int Id { get; set; }
    
    public string FullName { get; set; } = null!;
    
    public string PhoneNumber { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }
    
    public static UpdateUserResponse FromEntity(User entity)
    {
        return new UpdateUserResponse
        {
            Id = entity.Id,
            FullName = entity.FullName,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email,
            Password = entity.Password,
            IsAdmin = entity.IsAdmin
        };
    } 
}