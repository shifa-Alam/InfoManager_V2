using IM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Services
{
    public  interface IMemberService : IBaseService
    {
        public void Save(Member entity);
        public void SaveWithSkills(Member entity);
        public void Update(Member entity);
        public void DeleteById(long id);
        public void SoftDelete(Member entity);
        public Member FindById(long id);
        public IEnumerable<Member> Get();
        
    }
}
