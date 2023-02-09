
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace IM.Core.Models
{
    public class MemberViewModel
    {
        public MemberViewModel()
        {
            MemberSkills = new List<MemberSkillViewModel>();
        }
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string LanguageSkills =>
        MemberSkills.Any() ?string.Join(", ", MemberSkills.Where(e=>e.IsSelect).Select(x => $"{x.SkillName}")) :
        "No Skills.";


        public string Resume { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<MemberSkillViewModel> MemberSkills { get; set; }

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
