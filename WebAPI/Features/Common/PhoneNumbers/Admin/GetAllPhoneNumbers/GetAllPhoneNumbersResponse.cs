using System.Linq.Expressions;
using Cardinar.Features.Common.Entities;
using WebAPI.Features.Branches.Entity;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers;

public class GetAllPhoneNumbersResponse
{
    public int Id { get; set; }
    public bool IsAdmin { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
    
    public static Expression<Func<PhoneNumber, GetAllPhoneNumbersResponse>> project = p => new GetAllPhoneNumbersResponse()
        {
            Id = p.Id,
            PhoneNumber = p.Value
        
        };