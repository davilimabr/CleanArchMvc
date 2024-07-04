using CleanArchMvc.Application.DTOs;
using FluentValidation;

namespace CleanArchMvc.Application.Validations
{
    public class ClubDtoValidator : AbstractValidator<ClubDto>
    {
        public ClubDtoValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .LessThan(0);

            RuleFor(c => c.FullName)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100);

            RuleFor(c => c.ShortName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(c => c.YearFounded)
                .NotEmpty()
                .LessThan(0)
                .GreaterThan(DateTime.Now.Year);

            RuleFor(c => c.Stadium)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100);
        }
    }
}
