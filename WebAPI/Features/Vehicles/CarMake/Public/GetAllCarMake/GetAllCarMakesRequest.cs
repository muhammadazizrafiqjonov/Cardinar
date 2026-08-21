namespace WebAPI.Features.Vehicles.CarMake.Public.GetAllCarMake;

public class GetAllCarMakesRequest
{
    public string? Search { get; set; }
    public int? Size { get; set; }
    public int? Page { get; set; }
}