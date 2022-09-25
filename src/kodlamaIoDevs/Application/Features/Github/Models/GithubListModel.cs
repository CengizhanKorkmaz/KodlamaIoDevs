using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Github.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Github.Models
{
    public class GithubListModel:BasePageableModel
    {
        public IList<GithubListDto> Items { get; set; }

    }
}
