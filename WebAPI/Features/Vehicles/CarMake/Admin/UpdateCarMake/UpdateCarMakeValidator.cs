using FluentValidation;

namespace WebAPI.Features.Vehicles.CarMake.Admin.UpdateCarMake;

public class UpdateCarMakeValidator : Validator<UpdateCarMakeRequest>
{
    public UpdateCarMakeValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
    }
}