using FluentValidation;
using WebAPI.Features.Branches.Admin.CreateBranch;

namespace WebAPI.Features.Branches.Admin.UpdateBranch;

public class UpdateBranchValidator : Validator<UpdateBranchRequest>
{
    public UpdateBranchValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Region).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\+?[0-9]{9,15}$");
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
        RuleFor(x => x.BranchType).IsInEnum();
    }
    }