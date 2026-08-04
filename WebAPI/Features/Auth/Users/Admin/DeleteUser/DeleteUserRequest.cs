using WebAPI.Features.Auth.Entities;

namespace WebAPI.Features.Auth.Users.Admin.DeleteUser;

public class DeleteUserRequest
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public User ToEntity() => new User()
    {
        FullName = FullName,
        PhoneNumber = PhoneNumber,
        Email = Email,
        Password = Password
    };
}