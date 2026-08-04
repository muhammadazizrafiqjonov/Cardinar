using System.Linq.Expressions;
using WebAPI.Features.Auth.Entities;
using WebAPI.Features.Common.PhoneNumbers.Public.GetAllPhoneNumbers;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Auth.Users.Public.GetMe;

public class GetMeResponse
{
    public string FullName { get; set; } = null!;
    
    public string PhoneNumber { get; set; } = null!;
    
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    
    public static readonly Expression<Func<User, GetMeResponse>> Project = u => new GetMeResponse
    {
        FullName = u.FullName,
        PhoneNumber = u.PhoneNumber,
        Email = u.Email,
        Password = u.Password,
        IsAdmin = u.IsAdmin
        
    };
}