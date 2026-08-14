namespace WebAPI.Features.Branches.Admin.GetAllBranches;

public class GetAllBranchesRequest
{
    public string Email = null!;
    public string? Search { get; set; }
    public bool? IsAdmin { get; set; }
    public int? Size { get; set; }
    public int? Page { get; set; }
}