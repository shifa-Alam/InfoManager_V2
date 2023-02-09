using IM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Models
{
    public class MemberInputModel
    {
        public MemberInputModel()
        {
            MemberSkills = new List<MemberSkillInputModel>();
        }
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Resume { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<MemberSkillInputModel> MemberSkills { get; set; }

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
