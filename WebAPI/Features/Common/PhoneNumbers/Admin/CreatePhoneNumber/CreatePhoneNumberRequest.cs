using WebAPI.Features.Branches.Entity;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.CreatePhoneNumber;

public  class CreatePhoneNumberRequest
{
    public string Value { get; set; } = null!;

    public PhoneNumber ToEntity() => new PhoneNumber()
    {
        Value = Value
    };
}