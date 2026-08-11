using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;


namespace WebAPI.Features.Branches.Admin.CreateBranch;

public class CreateBranchEndpoint(CardinarDbContext ctx) : Endpoint<CreateBranchRequest, CreateBranchResponse>
{
    public override void Configure()
    {
        Post("v1/admin/branches/create-branch");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("Branches"));
    }

    public override async Task<CreateBranchResponse> ExecuteAsync(CreateBranchRequest req, CancellationToken ct)
    {
        var alreadyExists = await ctx.Branches
            .AnyAsync(b => EF.Functions.ILike(b.Title, req.Title), ct);
        AlreadyExistsException.ThrowIf(alreadyExists);

        var newBranch =  ctx.Branches.Add(req.ToEntity());
        await ctx.SaveChangesAsync(ct);

        return CreateBranchResponse.FromEntity(newBranch.Entity);
    }
}
