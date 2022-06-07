using FluentValidation;
using New.Api.Core.Models;

namespace News.Api.Host.Validators
{
    public class ArticleModelValidator : AbstractValidator<ArticleModel>
    {
        public ArticleModelValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty();

            RuleFor(m => m.Text)
                .NotEmpty();

            RuleFor(m => m.Tags)
               .NotEmpty();
        }
    }
}
