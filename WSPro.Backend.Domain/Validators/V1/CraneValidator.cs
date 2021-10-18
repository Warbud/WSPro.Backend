using System;
using FluentValidation;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Domain.Validators.V1
{
    public class CraneValidator:AbstractValidator<Crane>
    {
        public CraneValidator()
        {
            RuleFor(crane => crane.Name).Matches(@"^(?!00)(\d{2})$")
                .WithMessage("Nazwa żurawia nie pasuje do standardu!");
        }
    }
}