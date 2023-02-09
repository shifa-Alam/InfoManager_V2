using IM.Core.Entities;
using IM.Core.Infra.Repos;
using IM.Repo.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IM.Repo
{
    public class CityRepo : GenericRepository<City>, ICityRepo
    {
        public CityRepo(IMDBContext context) : base(context)
        {
        }

        public IEnumerable<City> GetByCountryId(long countryId)
        {
            return context.Cities.Where(e => e.CountryId == countryId);
        }
    }
}
