using WebAPI.Core.Enums;

namespace WebAPI.Features.Branches.Public.GetAllBranches;

public class GetAllBranchesRequest
{
    public string? Search { get; set; }
    public int? Size { get; set; }
    public int? Page { get; set; }
}