using IM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Services
{
    public  interface ICountryService : IBaseService
    {
        public void Save(Country entity);
        public void Update(Country entity);
        public void DeleteById(long id);
        public Country SoftDelete(Country entity);
        public Country FindById(long id);
        public IEnumerable<Country> Get();
      
    }
}
