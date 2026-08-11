using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Auth.Users.Admin.UpdateUser;

public class UpdateUserEndpoint(CardinarDbContext context) : Endpoint<UpdateUserRequest, UpdateUserResponse>
{
    public override void Configure()
    {
        Patch("v1/admin/users/update-user/{id:int}");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("Users"));
    }

    public override async Task<UpdateUserResponse> ExecuteAsync(UpdateUserRequest req, CancellationToken ct)
    {
        var updatedUserNumber = context.Users.Update(req.ToEntity());
        await context.SaveChangesAsync(ct);
        
        var ifExists =
            await context.PhoneNumbers.AnyAsync(p =>  p.Id == req.Id, ct);
        DoesNotExistsException.ThrowIf(ifExists);

        return UpdateUserResponse.FromEntity(updatedUserNumber.Entity);
    }
}