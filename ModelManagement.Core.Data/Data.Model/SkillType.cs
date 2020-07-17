using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class SkillType:Entity
    {
        public SkillType()
        {
            Skills = new List<Skill>();
        }
        public string SkillTypeId { get; set; }
        public string Description { get; set; }
        public virtual List<Skill> Skills { get; set; }

    }
}
