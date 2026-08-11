using WebAPI.Features.Auth.Entities;
using WebAPI.Features.Common.PhoneNumbers.Admin.UpdatePhoneNumber;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Auth.Users.Admin.UpdateUser;

public class UpdateUserResponse
{
    public int Id { get; set; }
    
    public static UpdateUserResponse FromEntity(User entity)
    {
        return new UpdateUserResponse
        {
            Id = entity.Id
        };
    } 
}