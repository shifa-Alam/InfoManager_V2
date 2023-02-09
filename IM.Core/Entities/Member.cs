using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Entities
{
    public class Member : BaseEntity
    {
        public Member()
        {
            MemberSkills = new HashSet<MemberSkill>();
        }

        
        public string Name { get; set; } = null!;
        public long CountryId { get; set; }
        public string Resume { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public long CityId { get; set; }
        

        public virtual City City { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<MemberSkill> MemberSkills { get; set; }
    }
}
