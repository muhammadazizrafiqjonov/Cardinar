using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Auth.Users.Admin.CreateUser;

public class CreateUserEndpoint(CardinarDbContext context) : Endpoint<CreateUserRequest, CreateUserResponse>
{
    public override void Configure()
    {
        Post("v1/admin/users/create-user");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("Users"));
    }

    public override async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest req, CancellationToken ct)
    {
        var alreadyExists =
            await context.Users.AnyAsync(u =>  u.FullName == req.FullName, ct);
        AlreadyExistsException.ThrowIf(alreadyExists);

        var newUser = context.Users.Add(req.ToEntity());
        await context.SaveChangesAsync(ct);

        return CreateUserResponse.FromEntity(newUser.Entity);
    }
}