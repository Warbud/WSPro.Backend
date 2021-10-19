using FluentValidation;
using WSPro.Backend.Application.Dto;

namespace WSPro.Backend.Application.Validators.Crane
{
    public class CreateCraneDtoValidator: AbstractValidator<CreateCraneDto>
    {
        public CreateCraneDtoValidator()
        {
            RuleFor(crane => crane.Name).Matches(@"^(?!00)(\d{2})$")
                .WithMessage("Nazwa żurawia nie pasuje do standardu!");
        }
    }

}