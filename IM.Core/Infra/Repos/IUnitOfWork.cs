using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Infra.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberRepo MemberR
        {
            get;
        }
        IMemberSkillRepo  MemberSkillR  
        {
            get;
        }
        ISkillRepo SkillR
        {
            get;
        }
        ICityRepo CityR  
        {
            get;
        }
        ICountryRepo CountryR
        {
            get;
        }
        int Save();
    }
}
