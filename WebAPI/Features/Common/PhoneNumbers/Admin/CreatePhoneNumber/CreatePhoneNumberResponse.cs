using WebAPI.Features.Branches.Entity;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.CreatePhoneNumber;

public class CreatePhoneNumberResponse
{
    // TODO: Idsini ham qo'shish kerak
    public int Id { get; set; }
    public string Value { get; set; }
    
    // TODO: FromEntity deb public static metod yaratib qo'yamiz 
    public static CreatePhoneNumberResponse FromEntity(PhoneNumber entity)
    {
        return new CreatePhoneNumberResponse
        {
            Id = entity.Id,
            Value = entity.Value
        };
    } 
}