using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.SubProgramLanguage.Commands.CreateSubProgramLanguage
{
    public class CreateSubProgramLanguageValidator:AbstractValidator<Domain.Entities.SubProgramLanguage>
    {
        public CreateSubProgramLanguageValidator()
        {
            RuleFor(x=>x.SubName).NotEmpty();
            RuleFor(x => x.SubName).NotNull();
            RuleFor(x => x.ProgramLanguage).NotEmpty();
            RuleFor(x => x.ProgramLanguage).NotNull();
        }
    }
}
