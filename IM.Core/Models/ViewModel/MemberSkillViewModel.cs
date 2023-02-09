using IM.Core.Entities;
using IM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Models
{
    public class MemberSkillViewModel
    {

        public long MemberId { get; set; }
        public long SkillId { get; set; }
        public string SkillName { get; set; }
        public string MemberName { get; set; }
        public bool IsSelect { get; set; }

        
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
