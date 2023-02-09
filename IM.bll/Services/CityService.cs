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
    public class CityService : BaseService, ICityService
    {
        private IUnitOfWork _repo;
        public CityService(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public void Save(City city)
        {
            city.Active = true;
            city.CreatedDate = DateTime.Now;

            _repo.CityR.Add(city);
            _repo.Save();
        }

        public void Update(City city)
        {
            var existingEntity = _repo.CityR.GetById(city.Id);

            //if (existingEntity != null)
            //{
            //    existingEntity.FirstName = city.FirstName;
            //    existingEntity.LastName = city.LastName;
            //    existingEntity.MobileNumber = city.MobileNumber;
            //    existingEntity.EmergencyContact = city.EmergencyContact;
            //    existingEntity.HomeDistrict = city.HomeDistrict;
            //    existingEntity.ModifiedDate = DateTime.Now;

            //    _repo.MemberR.Update(existingEntity);
            //    _repo.Save();
            //}


        }
        public void DeleteById(long id)
        {
            var city = _repo.CityR.GetById(id);
            _repo.CityR.Remove(city);
            _repo.Save();
        }
        public City SoftDelete(City city)
        {
            return city;
        }

        public City FindById(long id)
        {
            return _repo.CityR.GetById(id);
        }

        public IEnumerable<City> Get()
        {
            return _repo.CityR.GetAll();
        }



        public override void Dispose()
        {
            _repo?.Dispose();
        }

        public IEnumerable<City> GetByCountryId(long countryId)
        {
            return _repo.CityR.GetByCountryId(countryId);
        }
    }
}
