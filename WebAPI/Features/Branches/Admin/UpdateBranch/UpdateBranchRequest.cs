using WebAPI.Core.Enums;
using WebAPI.Features.Branches.Entity;

namespace WebAPI.Features.Branches.Admin.UpdateBranch;

public class UpdateBranchRequest
{
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    
    public string? District { get; set; }
    
    public string Region { get; set; } = null!;
    
    public string PhoneNumber { get; set; } = null!;
    
    public decimal Longitude { get; set; }
    
    public decimal Latitude { get; set; }

    public bool IsActive { get; set; } = true;
    
    public BranchType BranchType { get; set; }
    
    public Branch ToEntity() => new Branch()
    {
        Title = Title,
        Address = Address,
        District = District,
        Region = Region,
        PhoneNumber = PhoneNumber,
        IsActive = IsActive,
        Longitude = Longitude,
        Latitude = Latitude,
        BranchType = BranchType
    };
}