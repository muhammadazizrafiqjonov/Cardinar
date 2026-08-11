using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebAPI.Features.Auth.Entities;
using WebAPI.Features.Branches.Entity;
using WebAPI.Features.Common.Entities;
using WebAPI.Features.Products.Entities;
using WebAPI.Products.Entities;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI;

public class CardinarDbContext(DbContextOptions<CardinarDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<SocialLink> SocialLinks { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<CarMake> CarMakes { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new CarModelConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
}