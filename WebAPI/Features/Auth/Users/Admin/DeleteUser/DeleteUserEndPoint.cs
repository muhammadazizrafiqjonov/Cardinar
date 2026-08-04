using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Auth.Users.Admin.DeleteUser;

public class DeleteUserEndPoint(CardinarDbContext context) : Endpoint<DeleteUserRequest, NoContent>
{
    public override void Configure()
    {
        Delete("v1/admin/users/{id:int}");
        Tags("Admin");
        AllowAnonymous();
        Options(opts => opts.WithTags("Users"));
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == req.Id, ct);
        
        if (user is null)
        {
            throw new Exception("Bunday ID ga ega User mavjud emas!");
        }
        
        context.Users.Remove(user);

        await context.SaveChangesAsync(ct);

        await Send.NoContentAsync(ct);

    }
}