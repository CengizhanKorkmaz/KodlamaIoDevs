using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class SubProgramLanguage:Entity
    {
        public string SubName { get; set; }
        public int ProgramLanguageId { get; set; }
        public virtual ProgramLanguage? ProgramLanguage { get; set; }
        public SubProgramLanguage()
        {
            
        }

        public SubProgramLanguage(int id,string subName,int programLanguageId)
        {
            Id = id;
            SubName = subName;
            ProgramLanguageId=programLanguageId;
        }
    }
}
