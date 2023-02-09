using IM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Infra.Repos
{
    public interface ICityRepo : IGenericRepository<City>
    {
        IEnumerable<City> GetByCountryId(long countryId);
    }
}
