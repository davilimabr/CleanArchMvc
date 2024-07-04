using CleanArchMvc.Application.DTOs;
using FluentValidation;

namespace CleanArchMvc.Application.Validations
{
    public class PlayerDtoValidator : AbstractValidator<PlayerDto>
    {
        public PlayerDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .LessThan(0);

            RuleFor(p => p.FullName)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100);

            RuleFor(p => p.Height)
                .NotEmpty()
                .LessThan(0);

            RuleFor(p => p.Position)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(p => p.DateBirth)
                .NotEmpty();
        }
    }
}
