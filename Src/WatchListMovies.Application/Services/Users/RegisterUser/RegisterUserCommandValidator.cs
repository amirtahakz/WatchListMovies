using FluentValidation;
using WatchListMovies.Common.Application.Validation;

namespace WatchListMovies.Application.Services.Users.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {

            RuleFor(f => f.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
                .MinimumLength(4).WithMessage("کلمه عبور باید بشتر از 4 کارکتر باشد");

        }
    }
}
