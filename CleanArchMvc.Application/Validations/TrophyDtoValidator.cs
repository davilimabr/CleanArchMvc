using CleanArchMvc.Application.DTOs;
using FluentValidation;

namespace CleanArchMvc.Application.Validations
{
    public class TrophyDtoValidator : AbstractValidator<TrophyDto>
    {
        public TrophyDtoValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .LessThan(0);

            RuleFor(p => p.Competition)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100);

            RuleFor(c => c.Year)
                .NotEmpty()
                .LessThan(0)
                .GreaterThan(DateTime.Now.Year);
        }
    }
}
