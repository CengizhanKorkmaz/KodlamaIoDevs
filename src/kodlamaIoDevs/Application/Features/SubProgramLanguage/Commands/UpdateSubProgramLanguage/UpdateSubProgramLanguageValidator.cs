using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.SubProgramLanguage.Commands.UpdateSubProgramLanguage
{
    public class UpdateSubProgramLanguageValidator:AbstractValidator<Domain.Entities.SubProgramLanguage>
    {
        public UpdateSubProgramLanguageValidator()
        {
            RuleFor(x => x.SubName).NotEmpty();
            RuleFor(x => x.SubName).NotNull();
            RuleFor(x => x.ProgramLanguage).NotEmpty();
            RuleFor(x => x.ProgramLanguage).NotNull();
        }
    }
}
