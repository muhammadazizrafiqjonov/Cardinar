using WebAPI.Features.Branches.Entity;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.DeletePhoneNumber;

public class DeletePhoneNumberRequest
{
    public string Value { get; set; } = null!;
    
    public PhoneNumber ToEntity() => new PhoneNumber()
    {
        Value = Value
    };
}