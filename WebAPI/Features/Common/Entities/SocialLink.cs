using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Features.Common.Entities;

public class SocialLink : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string Link { get; set; } = null!;

}

public class SocialLinkConfiguration : IEntityTypeConfiguration<SocialLink>
{
    public void Configure(EntityTypeBuilder<SocialLink> builder)
    {
        // builder.ToTable("SocialLinks");
        // builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Title).IsUnique();
        builder.Property(x => x.Title).HasMaxLength(128).IsRequired(false);
        builder.Property(x => x.Icon).HasMaxLength(256).IsRequired();
        builder.Property(x => x.Link).HasMaxLength(256).IsRequired();

        builder.Property(x => x.CreatedAt).HasDefaultValueSql("NOW");
    }
}