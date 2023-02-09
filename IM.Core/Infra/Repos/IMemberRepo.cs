using IM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Infra.Repos
{
    public interface IMemberRepo : IGenericRepository<Member>
    {
        IEnumerable<Member> GetWithChild();
        void UpdateWithChild(Member entity);
    }
}
