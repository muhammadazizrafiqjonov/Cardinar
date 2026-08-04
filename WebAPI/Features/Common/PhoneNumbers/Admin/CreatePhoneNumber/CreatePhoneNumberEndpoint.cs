using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.CreatePhoneNumber;

public class CreatePhoneNumberEndpoint(CardinarDbContext context) : Endpoint<CreatePhoneNumberRequest, CreatePhoneNumberResponse>
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
        var alreadyExists =
            await context.PhoneNumbers.AnyAsync(p =>  p.Value == req.Value, ct);
        AlreadyExistsException.ThrowIf(alreadyExists);
        
        var newPhoneNumber = context.PhoneNumbers.Add(req.ToEntity());
        await context.SaveChangesAsync(ct);
        
        return CreatePhoneNumberResponse.FromEntity(newPhoneNumber.Entity);
    }
}