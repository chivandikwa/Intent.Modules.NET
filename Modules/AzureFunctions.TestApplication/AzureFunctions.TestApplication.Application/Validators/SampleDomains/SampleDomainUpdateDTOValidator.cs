using System;
using AzureFunctions.TestApplication.Application.SampleDomains;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.FluentValidation.Dtos.DTOValidator", Version = "1.0")]

namespace AzureFunctions.TestApplication.Application.Validators.SampleDomains
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class SampleDomainUpdateDTOValidator : AbstractValidator<SampleDomainUpdateDTO>
    {
        [IntentManaged(Mode.Fully)]
        public SampleDomainUpdateDTOValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Attribute)
                .NotNull();

        }
    }
}