using AutoBet.Domain.Entities;
using FluentValidation;

namespace AutoBet.Domain.Validations
{
    public class UserValidation  : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("USERNAME_EMPTY");
            RuleFor(o => o.Password).NotEmpty().WithMessage("PASSWORD_EMPTY");
        }
    }
}
