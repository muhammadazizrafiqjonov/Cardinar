using FluentValidation;

namespace WebAPI.Features.Vehicles.CarMake.Admin.CreateCarMake;

public class CreateCarMakeValidator : Validator<CreateCarMakeRequest>
{
    public CreateCarMakeValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
    }
}