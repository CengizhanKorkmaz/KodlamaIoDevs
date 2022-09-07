using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.ProgramLanguage.Commands.CreateProgramLanguage
{
    public class CreateProgramLanguageValidator:AbstractValidator<Domain.Entities.ProgramLanguage>
    {
        public CreateProgramLanguageValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);

        }
    }
}
