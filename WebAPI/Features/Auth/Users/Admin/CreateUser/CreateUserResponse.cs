using WebAPI.Features.Auth.Entities;

namespace WebAPI.Features.Auth.Users.Admin.CreateUser;

public class CreateUserResponse
{
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public static CreateUserResponse FromEntity(User entity)
    {
        return new CreateUserResponse()
        {
            FullName = entity.FullName,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email,
            Password = entity.Password
        };
    }
}