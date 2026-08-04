using Microsoft.EntityFrameworkCore;
using WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers;

namespace WebAPI.Features.Auth.Users.Public.GetMe;

public class GetMeEndpoint(CardinarDbContext context) : Endpoint<GetMeRequest, GetMeResponse>
{
    public override void Configure()
    {
        Get("v1/public/users/get-me");
        Policies("Public");
        Tags("Public");
        Options(opts => opts.WithTags("Auth"));
    }

    public override async Task<GetMeResponse> ExecuteAsync(GetMeRequest req, CancellationToken ct)
    {
        var user = await context.Users
            .Where(u => EF.Functions.ILike(u.Email, req.Email))
            .Select(GetMeResponse.Project)
            .FirstOrDefaultAsync(ct);
        
        if (user == null)
            throw new Exception("Unauthorized.");
        
        return user;
    }
}
