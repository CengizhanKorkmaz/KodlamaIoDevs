using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.ProgramLanguage.Commands.UpdateProgramLanguage
{
    public class UpdateProgramLanguageValidator:AbstractValidator<Domain.Entities.ProgramLanguage>
    {
        public UpdateProgramLanguageValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);

        }
    }
}
