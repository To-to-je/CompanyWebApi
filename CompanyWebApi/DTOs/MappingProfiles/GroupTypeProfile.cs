using AutoMapper;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DTOs;

namespace CompanyWebApi.DBOs.MappingProfiles
{
    public class GroupTypeProfile : Profile

    {

        public GroupTypeProfile()
        {

            CreateMap<GroupType, GroupTypeDto>()
                .ReverseMap()
                .ForMember(dest => dest.Companies, act => act.Ignore());

        }

    }
}
