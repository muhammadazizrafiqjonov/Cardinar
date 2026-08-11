using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Branches.Admin.DeleteBranch;

public class DeleteBranchEndpoint(CardinarDbContext ctx) : Endpoint<DeleteBranchRequest, NoContent>
{
    public override void Configure()
    {
        Delete("v1/admin/branches/delete-branch/{id}");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("Branches"));
    }

    public override async Task<NoContent> HandleAsync(DeleteBranchRequest req, CancellationToken ct)
    {
        var ifExists = await ctx.Branches
            .AnyAsync(b => Equals(b.Id, req.Id), ct);
        DoesNotExistsException.ThrowIf(ifExists);
        
        
        
    }
}