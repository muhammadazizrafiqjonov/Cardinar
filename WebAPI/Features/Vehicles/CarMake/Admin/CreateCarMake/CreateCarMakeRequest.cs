namespace WebAPI.Features.Vehicles.CarMake.Admin.CreateCarMake;



public class CreateCarMakeRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    
    public Entities.CarMake ToEntity() => new()
    {
       Title = Title,
    };
}
