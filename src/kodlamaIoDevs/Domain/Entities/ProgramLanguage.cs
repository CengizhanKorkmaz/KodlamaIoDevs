using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgramLanguage:Entity
    {
        public string Name { get; set; }
        public ICollection<SubProgramLanguage> SubProgramLanguages { get; set; }
        public ProgramLanguage(int id,string name):this()
        {
            Id=id;
            Name=name;
            
        }

        public ProgramLanguage()
        {
            
        }
    }
}
