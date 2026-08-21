namespace WebAPI.Features.Vehicles.CarMake.Admin.CreateCarMake;

public class CreateCarMakeResponse
{
    public string Title { get; set; } = null!;
    
    public static CreateCarMakeResponse FromEntity(Entities.CarMake entity)
    {
        return new CreateCarMakeResponse()
        {
            Title = entity.Title,
        };
    } 
}