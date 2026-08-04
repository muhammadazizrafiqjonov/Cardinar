using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Auth.Users.Admin.DeleteUser;

public class DeleteUserResponse
{
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public static DeleteUserResponse FromEntity(PhoneNumber entity)
    {
        return new DeleteUserResponse()
        {
           
        };
    } 
}