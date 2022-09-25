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

namespace Application.Features.Github.Commands.UpdateGithub
{
    public class UpdateGithubCommand:IRequest<UpdatedGithubDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateGithubHandler : IRequestHandler<UpdateGithubCommand, UpdatedGithubDto>
        {
            private readonly IGithubRepository _GithubRepository;
            private readonly IMapper _mapper;
            private readonly GithubBusinessRules _GithubBusinessRules;

            public UpdateGithubHandler(IGithubRepository GithubRepository, IMapper mapper, GithubBusinessRules GithubBusinessRules)
            {
                _GithubRepository = GithubRepository;
                _mapper = mapper;
                _GithubBusinessRules = GithubBusinessRules;
            }
            public async Task<UpdatedGithubDto> Handle(UpdateGithubCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Github? githubUpdated = await _GithubRepository.GetAsync(x => x.Id == request.Id); 
                githubUpdated.Name = request.Name;
                Domain.Entities.Github updatedGithub = await _GithubRepository.UpdateAsync(githubUpdated);
                UpdatedGithubDto updatedGithubDto = _mapper.Map<UpdatedGithubDto>(updatedGithub);

                return updatedGithubDto;

            }
        }
    }
}
