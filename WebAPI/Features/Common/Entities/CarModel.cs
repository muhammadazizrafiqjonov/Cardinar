using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Features.Common.Entities;

public class CarModel : BaseEntity
{
    [ForeignKey(nameof(CarMake))]
    public int CarMakeId { get; set; }
    public CarMake? CarMake { get; set; }
    
    public string Title { get; set; } = null!;
}

public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.HasOne(x => x.CarMake)
            .WithMany(y => y.CarModels)
            .HasForeignKey(x => x.CarMakeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
