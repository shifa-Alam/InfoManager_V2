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
    public class MemberRepo : GenericRepository<Member>, IMemberRepo
    {
        public MemberRepo(IMDBContext context) : base(context)
        {
        }

        public IEnumerable<Member> GetWithChild()
        {
            return context.Members.Where(e=>e.Active)
                 .Include(z => z.Country)
                 .Include(c => c.City)
                 .Include(e => e.MemberSkills).ThenInclude(x => x.Skill);
            //.Include(e => e.MemberSkills).ThenInclude(x => x.Member);
        }


        public void UpdateWithChild(Member model)
        {
            var existingParent = context.Members
                .Where(p => p.Id == model.Id)
                .Include(p => p.MemberSkills)
                .SingleOrDefault();

            if (existingParent != null)
            {
                // Update parent
                context.Entry(existingParent).CurrentValues.SetValues(model);

                // Delete children
                foreach (var existingChild in existingParent.MemberSkills.ToList())
                {
                    if (!model.MemberSkills.Any(c => c.Id == existingChild.Id))
                        context.MemberSkills.Remove(existingChild);
                }

                // Update and Insert children
                foreach (var childModel in model.MemberSkills)
                {
                    var existingChild = existingParent.MemberSkills
                        .Where(c => c.Id == childModel.Id && c.Id != default(int))
                        .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        context.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        // Insert child
                        var newChild = new MemberSkill
                        {
                            SkillId = childModel.SkillId,
                            IsSelect = childModel.IsSelect,
                            //...
                        };
                        existingParent.MemberSkills.Add(newChild);
                    }
                }
            }
        }
    }
}
