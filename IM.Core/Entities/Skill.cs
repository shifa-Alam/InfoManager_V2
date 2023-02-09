using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Entities
{
    public class Skill:BaseEntity
    {

        public Skill()
        {
            MemberSkills = new HashSet<MemberSkill>();
        }

        
        public string Name { get; set; } = null!;


        public virtual ICollection<MemberSkill> MemberSkills { get; set; }
    }
}
