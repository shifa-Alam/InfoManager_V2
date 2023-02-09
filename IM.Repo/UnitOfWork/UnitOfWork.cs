using IM.Core.Entities;
using IM.Core.Infra.Repos;
using IM.Repo.DBContext;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private IMDBContext _context;
        public UnitOfWork(IMDBContext context)
        {
            _context = context;
            MemberR = new MemberRepo(_context);
            SkillR = new SkillRepo(_context);
            CityR = new CityRepo(_context);
            CountryR = new CountryRepo(_context);
            MemberSkillR = new MemberSkillRepo(_context);
        }

        public IMemberRepo MemberR
        {
            get;
            private set;
        }

        public ISkillRepo SkillR
        {
            get;
            private set;
        }

        public ICityRepo CityR
        {
            get;
            private set;
        }

        public ICountryRepo CountryR
        {
            get;
            private set;
        }

        public IMemberSkillRepo MemberSkillR
        {
            get;
            private set;
        }
        public virtual void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
