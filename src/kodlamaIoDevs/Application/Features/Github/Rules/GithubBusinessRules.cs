using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

namespace Application.Features.Github.Rules
{
    public class GithubBusinessRules
    {
        private IGithubRepository _githubRepository;

        public GithubBusinessRules(IGithubRepository githubRepository)
        {
            _githubRepository = githubRepository;
        }

        public async Task GithubNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.Github> result = await _githubRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Github name exists");
        }
    }
}
