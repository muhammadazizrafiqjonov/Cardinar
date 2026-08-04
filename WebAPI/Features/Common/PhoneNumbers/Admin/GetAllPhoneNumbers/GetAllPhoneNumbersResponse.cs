using System.Linq.Expressions;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers;

public class GetAllPhoneNumbersResponse
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public static readonly Expression<Func<PhoneNumber, GetAllPhoneNumbersResponse>> Project = p => new GetAllPhoneNumbersResponse
    {
        Id = p.Id,
        PhoneNumber = p.Value,
        CreatedAt = p.CreatedAt,
        UpdatedAt = p.UpdatedAt
    };
}