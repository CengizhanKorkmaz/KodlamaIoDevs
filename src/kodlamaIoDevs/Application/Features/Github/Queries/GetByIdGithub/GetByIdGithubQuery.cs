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

namespace Application.Features.Github.Queries.GetByIdGithub
{
    public class GetByIdGithubQuery:IRequest<GithubGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdGithubQueryHandler : IRequestHandler<GetByIdGithubQuery, GithubGetByIdDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;
            private readonly GithubBusinessRules _businessRules;

            public GetByIdGithubQueryHandler(IGithubRepository githubRepository, IMapper mapper, GithubBusinessRules businessRules)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<GithubGetByIdDto> Handle(GetByIdGithubQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.Github? github = await _githubRepository.GetAsync(x=>x.Id==request.Id);
                GithubGetByIdDto githubGetByIdDto = _mapper.Map<GithubGetByIdDto>(github);
                return githubGetByIdDto;
            }
        }
    }
    
}
