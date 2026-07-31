using Cardinar.Features.Common.Entities;
using FastEndpoints;
using WebAPI.Features.Branches.Entity;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace Cardinar.Features.Common.PhoneNumbers.Admin.UpdatePhoneNumber;

public class UpdatePhoneNumberRequest
{
    [RouteParam]
    public int Id { get; set; }
    public string? Value { get; set; }
    
    public PhoneNumber ToEntity() => new PhoneNumber()
    {
        Value = Value
    };
}