using IM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Services
{
    public  interface ICityService : IBaseService
    {
        public void Save(City entity);
        public void Update(City entity);
        public void DeleteById(long id);
        public City SoftDelete(City entity);
        public City FindById(long id);
        public IEnumerable<City> Get();
        public IEnumerable<City> GetByCountryId(long countryId);

    }
}
