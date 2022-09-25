using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Github.Commands.CreateGithub
{
    public class CreateGithubValidator:AbstractValidator<Domain.Entities.Github>
    {
        public CreateGithubValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).MinimumLength(5);

        }
    }
}
