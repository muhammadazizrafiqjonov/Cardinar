namespace WebAPI.Features.Common.PhoneNumbers.Admin.CreatePhoneNumber;

public class CreatePhoneNumberEndpoint() : Endpoint<CreatePhoneNumberRequest, CreatePhoneNumberResponse>
{
    public override void Configure()
    {
        Post("v1/admin/phone-numbers/create-phone-number");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("PhoneNumber"));
    }

    public override async Task<CreatePhoneNumberResponse> ExecuteAsync(CreatePhoneNumberRequest req, CancellationToken ct)
    {
    }
}