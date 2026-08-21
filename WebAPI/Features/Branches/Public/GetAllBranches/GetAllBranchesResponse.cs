using System.Linq.Expressions;
using WebAPI.Core.Enums;
using WebAPI.Features.Branches.Entity;

namespace WebAPI.Features.Branches.Public.GetAllBranches;

public class GetAllBranchesResponse
{
    public string Title { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    
    public string? District { get; set; }
    
    public string Region { get; set; } = null!;
    
    public string PhoneNumber { get; set; } = null!;

    public bool IsActive { get; set; } = true;
    
    public BranchType BranchType { get; set; }

    
    public static readonly Expression<Func<Branch, GetAllBranchesResponse>> Project = b => new GetAllBranchesResponse
    {
        Title = b.Title,
        Address = b.Address,
        District = b.District,
        Region = b.Region,
        PhoneNumber = b.PhoneNumber,
        IsActive = b.IsActive,
        BranchType = b.BranchType,
    };
}