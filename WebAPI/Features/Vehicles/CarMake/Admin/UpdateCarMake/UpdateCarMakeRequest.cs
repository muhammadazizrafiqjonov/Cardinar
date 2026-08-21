namespace WebAPI.Features.Vehicles.CarMake.Admin.UpdateCarMake;

public class UpdateCarMakeRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    
    public Entities.CarMake ToEntity() => new()
    {
        Title = Title
    };
        
}