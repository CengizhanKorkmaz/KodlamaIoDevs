using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubProgramLanguage.Dtos
{
    public class SubProgramLanguageGetByIdDto
    {
        public int Id { get; set; }
        public string SubName { get; set; }
        public int ProgramLanguageId { get; set; }
    }
}
