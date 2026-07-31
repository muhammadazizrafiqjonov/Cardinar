using WebAPI.Features.Branches.Entity;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.DeletePhoneNumber;

public class DeletePhoneNumberResponse
{
    public int Id { get; set; }
    public string Value { get; set; } = null!;
    
    public static DeletePhoneNumberResponse FromEntity(PhoneNumber entity)
    {
        return new DeletePhoneNumberResponse
        {
            Id = entity.Id,
            Value = entity.Value
        };
    } 
}