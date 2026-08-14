using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Branches.Admin.GetAllBranches;

public class GetAllBranchesEndpoint(CardinarDbContext ctx) : Endpoint<GetAllBranchesRequest, PaginatedResponse<GetAllBranchesResponse>>
{
    public override void Configure()
    {
        Get("v1/admin/branches/get-all-branches");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("Branches"));
    }

    public override async Task<PaginatedResponse<GetAllBranchesResponse>> ExecuteAsync(GetAllBranchesRequest req, CancellationToken ct)
    {
        var ifExists = await ctx.Users.AnyAsync(u => u.Email == req.Email, ct);
        DoesNotExistsException.ThrowIf(ifExists);

        var hasPermission = await ctx.Users.AnyAsync(u => u.IsAdmin == req.IsAdmin);
        ForbiddenException.ThrowIf(hasPermission);
        
        var currentPage = req.Page ?? 1;
        var take = req.Size ?? 10;
        var skip = (currentPage - 1) * take;
        
        var query = ctx.Branches.AsNoTracking();

        if (!string.IsNullOrEmpty(req.Search))
            query = query.Where(b => EF.Functions.ILike(b.Title, $"%{req.Search}%"));
        

        var totalCount = await query.CountAsync(ct);
        var totalPages = (int)Math.Ceiling((double)totalCount / (req.Size ?? take));
        var data = await query.Select(GetAllBranchesResponse.Project).Skip(skip).Take(take).ToArrayAsync(ct);

        return PaginatedResponse<GetAllBranchesResponse>.BuildFrom(totalCount, totalPages, currentPage, data);
        
        
    }
}