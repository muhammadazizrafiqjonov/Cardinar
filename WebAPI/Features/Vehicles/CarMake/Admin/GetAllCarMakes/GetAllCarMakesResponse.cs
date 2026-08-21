using System.Linq.Expressions;

namespace WebAPI.Features.Vehicles.CarMake.Admin.GetAllCarMakes;

public class GetAllCarMakesResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    
    public static readonly Expression<Func<Entities.CarMake, GetAllCarMakesResponse>> Project = c => new GetAllCarMakesResponse
    {
        Id = c.Id,
        Title = c.Title,
    };
}