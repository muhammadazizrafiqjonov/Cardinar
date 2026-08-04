namespace WebAPI.Features.Common.PhoneNumbers.Public.GetAllPhoneNumbers;

public class GetAllPhoneNumbersRequest
{
    public string Value { get; set; } = null!;
    
    public string? Search { get; set; }
    public int? Size { get; set; }
    public int? Page { get; set; }
}