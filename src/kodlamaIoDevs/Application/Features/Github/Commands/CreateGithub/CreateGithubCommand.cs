using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Github.Dtos;
using Application.Features.Github.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Github.Commands.CreateGithub
{
    public class CreateGithubCommand:IRequest<CreatedGithubDto>
    {
        public string Name { get; set; }

        public class CreateGithubLanguageHandler : IRequestHandler<CreateGithubCommand, CreatedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;
            private readonly GithubBusinessRules _githubBusinessRules;

            public CreateGithubLanguageHandler(IGithubRepository githubRepository, IMapper mapper, GithubBusinessRules githubBusinessRules)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
                _githubBusinessRules = githubBusinessRules;
            }

            public async Task<CreatedGithubDto> Handle(CreateGithubCommand request, CancellationToken cancellationToken)
            {
                await _githubBusinessRules.GithubNameCanNotBeDuplicatedWhenInserted(request.Name);

                Domain.Entities.Github mappedGithub = _mapper.Map<Domain.Entities.Github>(request);
                Domain.Entities.Github createdGithub = await _githubRepository.AddAsync(mappedGithub);
                CreatedGithubDto createdGithubDto = _mapper.Map<CreatedGithubDto>(createdGithub);
                return createdGithubDto;

            }
        }
    }
}
