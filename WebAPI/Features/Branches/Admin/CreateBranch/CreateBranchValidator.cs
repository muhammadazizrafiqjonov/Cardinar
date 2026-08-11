using FastEndpoints;
using FluentValidation;

namespace WebAPI.Features.Branches.Admin.CreateBranch;

public class CreateBranchValidator : Validator<CreateBranchRequest>
{
    public CreateBranchValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Region).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty().EmailAddress();
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
    }
}