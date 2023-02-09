using IM.Core.Entities;
using IM.Core.Infra.Repos;
using IM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.bll.Services
{
    public class CountryService : BaseService, ICountryService
    {
        private IUnitOfWork _repo;
        public CountryService(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public void Save(Country country)
        {
            country.Active = true;
            country.CreatedDate = DateTime.Now;

            _repo.CountryR.Add(country);
            _repo.Save();
        }

        public void Update(Country country)
        {
            var existingEntity = _repo.CountryR.GetById(country.Id);

            //if (existingEntity != null)
            //{
            //    existingEntity.FirstName = country.FirstName;
            //    existingEntity.LastName = country.LastName;
            //    existingEntity.MobileNumber = country.MobileNumber;
            //    existingEntity.EmergencyContact = country.EmergencyContact;
            //    existingEntity.HomeDistrict = country.HomeDistrict;
            //    existingEntity.ModifiedDate = DateTime.Now;

            //    _repo.MemberR.Update(existingEntity);
            //    _repo.Save();
            //}


        }
        public void DeleteById(long id)
        {
            var country = _repo.CountryR.GetById(id);
            _repo.CountryR.Remove(country);
            _repo.Save();
        }
        public Country SoftDelete(Country country)
        {
            return country;
        }

        public Country FindById(long id)
        {
            return _repo.CountryR.GetById(id);
        }

        public IEnumerable<Country> Get()
        {
            return _repo.CountryR.GetAll();
        }



        public override void Dispose()
        {
            _repo?.Dispose();
        }

        
    }
}
