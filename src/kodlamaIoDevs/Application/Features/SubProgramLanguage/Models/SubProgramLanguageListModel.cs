using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;

namespace Application.Features.SubProgramLanguage.Models
{
    public class SubProgramLanguageListModel:BasePageableModel
    {
        public IList<SubProgramLanguageListModel> Type { get; set; }

    }
}
