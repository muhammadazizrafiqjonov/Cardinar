namespace WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers;

public class GetAllPhoneNumbersRequest
{
    public string Value { get; set; } = null!;
    
    public string? Search { get; set; }
    public bool? IsAdmin { get; set; }
    public int? Size { get; set; }
    public int? Page { get; set; }
}