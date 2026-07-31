using System.Linq.Expressions;
using Cardinar.Features.Common.Entities;
using WebAPI.Features.Branches.Entity;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Common.PhoneNumbers.Public.GetAllPhoneNumbers;

public class GetAllPhoneNumbersResponse
{
    public int Id { get; set; }
    public bool IsAdmin { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
    
public static class Expression<Func<PhoneNumber, GetAllPhoneNumbersResponse>> Project = p => new GetAllPhoneNumbersResponse()
{
    Id = p.Id,
    PhoneNumber = p.Value
        
};