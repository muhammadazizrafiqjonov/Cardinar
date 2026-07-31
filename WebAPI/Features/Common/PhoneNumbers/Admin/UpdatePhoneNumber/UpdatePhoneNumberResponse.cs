using WebAPI.Features.Branches.Entity;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.UpdatePhoneNumber;

public class UpdatePhoneNumberResponse
{
    public int Id { get; set; }
    public string Value { get; set; } = null!;
    
    public static UpdatePhoneNumberResponse FromEntity(PhoneNumber entity)
    {
        return new UpdatePhoneNumberResponse
        {
            Id = entity.Id,
            Value = entity.Value
        };
    } 
}