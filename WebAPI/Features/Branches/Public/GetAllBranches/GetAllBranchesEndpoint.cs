using Microsoft.EntityFrameworkCore;

namespace WebAPI.Features.Branches.Public.GetAllBranches;

public class GetAllBranchesEndpoint(CardinarDbContext context) : Endpoint<GetAllBranchesRequest, PaginatedResponse<GetAllBranchesResponse>>
{
    public override void Configure()
    {
        Get("v1/public/branches/get-all-branches");
        Policies("Public");
        Tags("Public");
        Options(opts => opts.WithTags("Branches"));
    }

    public override async Task<PaginatedResponse<GetAllBranchesResponse>> ExecuteAsync(GetAllBranchesRequest req, CancellationToken ct)
    {
        
        var currentPage = req.Page ?? 1;
        var take = req.Size ?? 10;
        var skip = (currentPage - 1) * take;
        
        
        var query = context.Branches.AsNoTracking();

        if (!string.IsNullOrEmpty(req.Search))
            query = query.Where(b => EF.Functions.ILike(b.Title, $"%{req.Search}%"));
        

        var totalCount = await query.CountAsync(ct);
        var totalPages = (int)Math.Ceiling((double)totalCount / (req.Size ?? take));
        var data = await query.Select(GetAllBranchesResponse.Project).Skip(skip).Take(take).ToArrayAsync(ct);

        return PaginatedResponse<GetAllBranchesResponse>.BuildFrom(totalCount, totalPages, currentPage, data);
    }
}