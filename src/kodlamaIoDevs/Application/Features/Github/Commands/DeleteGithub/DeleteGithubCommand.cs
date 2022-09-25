using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Github.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Github.Commands.DeleteGithub
{
    public  class DeleteGithubCommand:IRequest<DeletedGithubDto>
    {
        public int Id { get; set; }

        public class DeleteGithubHandler : IRequestHandler<DeleteGithubCommand, DeletedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;

            public DeleteGithubHandler(IGithubRepository githubRepository, IMapper mapper)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
            }

            public async Task<DeletedGithubDto> Handle(DeleteGithubCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Github? githubDeleted = await _githubRepository.GetAsync(x => x.Id == request.Id);
                Domain.Entities.Github deletedGithub = await _githubRepository.DeleteAsync(githubDeleted);
                DeletedGithubDto deletedGithubDto = _mapper.Map<DeletedGithubDto>(deletedGithub);
                return deletedGithubDto;

            }
        }
    }
}
