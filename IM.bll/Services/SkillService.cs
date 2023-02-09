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
    public class SkillService : BaseService, ISkillService
    {
        private IUnitOfWork _repo;
        public SkillService(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public void Save(Skill skill)
        {
            skill.Active = true;
            skill.CreatedDate = DateTime.Now;

            _repo.SkillR.Add(skill);
            _repo.Save();
        }

        public void Update(Skill skill)
        {
            var existingEntity = _repo.SkillR.GetById(skill.Id);

            //if (existingEntity != null)
            //{
            //    existingEntity.FirstName = skill.FirstName;
            //    existingEntity.LastName = skill.LastName;
            //    existingEntity.MobileNumber = skill.MobileNumber;
            //    existingEntity.EmergencyContact = skill.EmergencyContact;
            //    existingEntity.HomeDistrict = skill.HomeDistrict;
            //    existingEntity.ModifiedDate = DateTime.Now;

            //    _repo.MemberR.Update(existingEntity);
            //    _repo.Save();
            //}


        }
        public void DeleteById(long id)
        {
            var skill = _repo.SkillR.GetById(id);
            _repo.SkillR.Remove(skill);
            _repo.Save();
        }
        public Skill SoftDelete(Skill skill)
        {
            return skill;
        }

        public Skill FindById(long id)
        {
            return _repo.SkillR.GetById(id);
        }

        public IEnumerable<Skill> Get()
        {
            return _repo.SkillR.GetAll();
        }



        public override void Dispose()
        {
            _repo?.Dispose();
        }

        
    }
}
