using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Entities
{
    public class MemberSkill : BaseEntity
    {
       
        public long MemberId { get; set; }
        public long SkillId { get; set; }
        public bool IsSelect { get; set; }

        public virtual Skill Skill { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
       

    }
}
