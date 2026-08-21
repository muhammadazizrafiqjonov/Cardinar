using FluentValidation;

namespace WebAPI.Features.Auth.Users.Admin.CreateUser;

public class CreateUserValidator : Validator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^\+?[0-9]{9,15}$");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
 