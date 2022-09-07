using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgramLanguage.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProgramLanguage.Models
{
    public class ProgramLanguageListModel:BasePageableModel
    {
        public IList<ProgramLanguageListDto> Type { get; set; }
    }
}
