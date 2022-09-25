using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Github.Commands.UpdateGithub
{
    public class UpdateGithubValidator:AbstractValidator<Domain.Entities.Github>
    {
        public UpdateGithubValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).MinimumLength(5);
        }
        
    }
}
