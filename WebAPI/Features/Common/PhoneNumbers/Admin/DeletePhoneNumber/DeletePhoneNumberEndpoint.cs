using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.DeletePhoneNumber;

public class DeletePhoneNumberEndpoint(CardinarDbContext context) : Endpoint<DeletePhoneNumberRequest, DeletePhoneNumberResponse>
{
    public override void Configure()
    {
        Delete("v1/admin/phone-numbers/delete-phone-number");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("PhoneNumber"));
    }

    public override async Task<DeletePhoneNumberResponse> ExecuteAsync(DeletePhoneNumberRequest req, CancellationToken ct)
    {
        var ifExists =
            await context.PhoneNumbers.AnyAsync(p =>  p.Value == req.Value, ct);
        DoesNotExistsException.ThrowIf(ifExists);
        
        var currentPhoneNumber = context.PhoneNumbers.Remove(req.ToEntity());
        await context.SaveChangesAsync(ct);

        return DeletePhoneNumberResponse.FromEntity(currentPhoneNumber.Entity);
    }
}