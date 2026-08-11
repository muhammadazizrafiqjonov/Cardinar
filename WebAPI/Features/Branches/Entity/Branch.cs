using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Enums;

namespace WebAPI.Features.Branches.Entity;

public class Branch : BaseEntity
{
    [StringLength(128)]
    public string Title { get; set; } = null!;
    
    [StringLength(128)]
    public string Address { get; set; } = null!;
    
    [StringLength(64)]
    public string? District { get; set; }
    
    [StringLength(64)]
    public string Region { get; set; } = null!;
    
    [StringLength(16)]
    public string PhoneNumber { get; set; } = null!;
    
    [Precision(12, 9)]
    public decimal Longitude { get; set; }
    
    [Precision(12, 9)]
    public decimal Latitude { get; set; }

    public bool IsActive { get; set; } = true;
    
    public BranchType BranchType { get; set; }
}