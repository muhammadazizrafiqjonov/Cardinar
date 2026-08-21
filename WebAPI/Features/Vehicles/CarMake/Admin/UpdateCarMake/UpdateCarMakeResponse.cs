namespace WebAPI.Features.Vehicles.CarMake.Admin.UpdateCarMake;

public class UpdateCarMakeResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public static UpdateCarMakeResponse FromEntity(Entities.CarMake entity)
    {
        return new UpdateCarMakeResponse
        {
            Id = entity.Id,
            Title = entity.Title,
        };
    } 
}