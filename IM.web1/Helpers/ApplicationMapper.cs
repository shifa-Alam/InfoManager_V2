using AutoMapper;
using IM.Core.Entities;
using IM.Core.Models;


namespace IM.Web1.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<MemberSkillInputModel, MemberSkill>();
            CreateMap<MemberInputModel, Member>();

            CreateMap<MemberSkill, MemberSkillViewModel>()
                .ForMember(dest => dest.SkillName, m => m.MapFrom(src => src.Skill.Name))
                .ForMember(dest => dest.MemberName, m => m.MapFrom(src => src.Member.Name));

            CreateMap<Member, MemberViewModel>()
                .ForMember(dest => dest.CityName, m => m.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.CountryName, m => m.MapFrom(src => src.Country.Name));
        }
    }
}
