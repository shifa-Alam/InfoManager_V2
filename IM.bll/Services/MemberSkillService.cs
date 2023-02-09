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
    public class MemberSkillService : BaseService, IMemberSkillService
    {
        private IUnitOfWork _repo;
        public MemberSkillService(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public void Save(MemberSkill MemberSkill)
        {
            MemberSkill.Active = true;
            MemberSkill.CreatedDate = DateTime.Now;

            _repo.MemberSkillR.Add(MemberSkill);
            _repo.Save();
        }

        public void OnMemberSave(Member entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                foreach (var memberSkill in entity.MemberSkills)
                {
                    memberSkill.Active = true;
                    memberSkill.CreatedDate = entity.CreatedDate;
                  
                    //_repo.MemberSkillR.Add(memberSkill);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(MemberSkill MemberSkill)
        {
            var existingEntity = _repo.MemberSkillR.GetById(MemberSkill.Id);

            //if (existingEntity != null)
            //{
            //    existingEntity.FirstName = MemberSkill.FirstName;
            //    existingEntity.LastName = MemberSkill.LastName;
            //    existingEntity.MobileNumber = MemberSkill.MobileNumber;
            //    existingEntity.EmergencyContact = MemberSkill.EmergencyContact;
            //    existingEntity.HomeDistrict = MemberSkill.HomeDistrict;
            //    existingEntity.ModifiedDate = DateTime.Now;

            //    _repo.MemberR.Update(existingEntity);
            //    _repo.Save();
            //}


        }
        public void DeleteById(long id)
        {
            var MemberSkill = _repo.MemberSkillR.GetById(id);
            _repo.MemberSkillR.Remove(MemberSkill);
            _repo.Save();
        }
        public MemberSkill SoftDelete(MemberSkill MemberSkill)
        {
            return MemberSkill;
        }

        public MemberSkill FindById(long id)
        {
            return _repo.MemberSkillR.GetById(id);
        }

        public IEnumerable<MemberSkill> Get()
        {
            return _repo.MemberSkillR.GetAll();
        }


        public void OnMemberDelete(Member member)
        {
            try
            {
                if (member is null)
                {
                    throw new ArgumentNullException(nameof(member));
                }

                foreach (var memberSkill in member.MemberSkills)
                {
                    memberSkill.Active = false;
                    memberSkill.ModifiedDate = member.ModifiedDate;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public override void Dispose()
        {
            _repo?.Dispose();
        }

       
    }
}
