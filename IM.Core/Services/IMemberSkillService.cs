using IM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Services
{
    public  interface IMemberSkillService : IBaseService
    {
        public void Save(MemberSkill entity);
        public void OnMemberSave(Member entity);
        public void Update(MemberSkill entity);
        public void DeleteById(long id);
        public MemberSkill SoftDelete(MemberSkill entity);
        public MemberSkill FindById(long id);
        public IEnumerable<MemberSkill> Get();
        void OnMemberDelete(Member member);
    }
}
