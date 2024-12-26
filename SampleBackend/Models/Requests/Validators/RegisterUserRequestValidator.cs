using FluentValidation;

namespace SampleBackend.Models.Requests.Validators;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(model => model.Email).EmailAddress().WithMessage("Этот email не email (");
        RuleFor(model => model.Password).MinimumLength(8);
        RuleFor(model => model.Name).MaximumLength(50).MinimumLength(2);
        RuleFor(model => model.LastName).MaximumLength(50).MinimumLength(2);
    }
}
