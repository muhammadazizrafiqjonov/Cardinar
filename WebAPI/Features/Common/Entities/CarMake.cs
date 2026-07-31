namespace WebAPI.Features.Common.Entities;

public class CarMake : BaseEntity
{
    public string Title { get; set; } = null!;

    public ICollection<CarModel> CarModels { get; set; } = [];
}