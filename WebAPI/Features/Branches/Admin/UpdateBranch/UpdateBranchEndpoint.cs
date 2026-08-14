using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Branches.Admin.UpdateBranch;

public class UpdateBranchEndpoint(CardinarDbContext ctx) : Endpoint<UpdateBranchRequest, UpdateBranchResponse>
{
    public override void Configure()
    {
        Patch("v1/admin/branches/update-branch/{id}");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("Branches"));
    }

    public override async Task<UpdateBranchResponse> ExecuteAsync(UpdateBranchRequest req, CancellationToken ct)
    {
        var ifExists =
            await ctx.Branches.AnyAsync(b =>  b.Id == req.Id, ct);
        DoesNotExistsException.ThrowIf(ifExists);
        
        var updatedBranch = ctx.Branches.Update(req.ToEntity());
        await ctx.SaveChangesAsync(ct);

        return UpdateBranchResponse.FromEntity(updatedBranch.Entity);
        
    }
}