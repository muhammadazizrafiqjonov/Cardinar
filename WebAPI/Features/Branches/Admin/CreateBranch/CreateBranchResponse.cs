using WebAPI.Core.Enums;
using WebAPI.Features.Branches.Entity;

namespace WebAPI.Features.Branches.Admin.CreateBranch;

public class CreateBranchResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? District { get; set; }
    public string Region { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public bool IsActive { get; set; }
    public BranchType BranchType { get; set; }
    
    
    public static CreateBranchResponse FromEntity(Branch entity)
    {
        return new CreateBranchResponse()
        {
            Id = entity.Id,
            Title = entity.Title,
            Address = entity.Address,
            District = entity.District,
            Region = entity.Region,
            PhoneNumber = entity.PhoneNumber,
            Longitude = entity.Longitude,
            Latitude = entity.Latitude,
            IsActive = entity.IsActive,
            BranchType = entity.BranchType
        };
    }
}