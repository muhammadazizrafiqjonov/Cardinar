using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.UpdatePhoneNumber;

public class UpdatePhoneNumberEndpoint(CardinarDbContext context) : Endpoint<UpdatePhoneNumberRequest, UpdatePhoneNumberResponse>
{
    public override void Configure()
    {
        Patch("v1/admin/phone-numbers/update-phone-number/{id:int}");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("PhoneNumber"));
    }

    public override async Task<UpdatePhoneNumberResponse> ExecuteAsync(UpdatePhoneNumberRequest req, CancellationToken ct)
    {
        
        
        var updatedPhoneNumber = context.PhoneNumbers.Update(req.ToEntity());
        await context.SaveChangesAsync(ct);
        
        var ifExists =
            await context.PhoneNumbers.AnyAsync(p =>  p.Value == req.Value, ct);
        DoesNotExistsException.ThrowIf(ifExists);

        return UpdatePhoneNumberResponse.FromEntity(updatedPhoneNumber.Entity);
    }
}