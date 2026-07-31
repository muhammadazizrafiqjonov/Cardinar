using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
        if (user == null)
        {
            throw new Exception("User with given id does not exists");
        }

        context.Users.Remove(user);

        await context.SaveChangesAsync(ct);

        await Send.NoContentAsync(ct);

    }
}