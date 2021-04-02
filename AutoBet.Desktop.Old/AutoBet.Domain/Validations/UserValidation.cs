using AutoBet.Domain.Entities;
using FluentValidation;

namespace AutoBet.Domain.Validations
{
    /// <summary>
    /// Validation for the <see cref="User"/> entity class.
    /// </summary>
    public class UserValidation  : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("USERNAME_EMPTY");
            RuleFor(o => o.Password).NotEmpty().WithMessage("PASSWORD_EMPTY");
        }
    }
}
