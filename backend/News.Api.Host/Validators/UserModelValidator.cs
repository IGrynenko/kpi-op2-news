using FluentValidation;
using New.Api.Core.Models;

namespace News.Api.Host.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(m => m.Login)
                .NotEmpty();

            RuleFor(m => m.Password)
                .NotEmpty();
        }
    }
}
