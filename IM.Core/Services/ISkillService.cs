using IM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Services
{
    public  interface ISkillService : IBaseService
    {
        public void Save(Skill entity);
        public void Update(Skill entity);
        public void DeleteById(long id);
        public Skill SoftDelete(Skill entity);
        public Skill FindById(long id);
        public IEnumerable<Skill> Get();
      
    }
}
