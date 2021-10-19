using FluentValidation;
using WSPro.Backend.Application.Dto;

namespace WSPro.Backend.Application.Validators.Level
{
    public class CreateLevelDtoValidator:AbstractValidator<CreateLevelDto>
    {
        public CreateLevelDtoValidator()
        {
            RuleFor(l => l.Name).Matches(@"F|B\d{2}|L\d{2}").WithMessage("Nazwa poziomu nie pasuje do stanradtu");
        }
    }
}