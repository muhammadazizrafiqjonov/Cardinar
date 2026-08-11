using WebAPI.Features.Auth.Entities;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Auth.Users.Admin.UpdateUser;

public class UpdateUserRequest
{
    [RouteParam]
    public int Id { get; set; }
    
    public User ToEntity() => new User()
    {
        Id = Id
    };
}