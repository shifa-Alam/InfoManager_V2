using IM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Models
{
    public class MemberSkillInputModel
    {

        public long MemberId { get; set; }
        public long SkillId { get; set; }
        public bool IsSelect { get; set; }
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
