using AutoMapper;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DTOs;

namespace CompanyWebApi.DBOs.MappingProfiles
{
    public class CompanyProfile : Profile
    {

        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ReverseMap()
                .ForMember(dest => dest.Orders, act => act.Ignore())
                .ForMember(dest => dest.Appointments, act => act.Ignore())
                .ForMember(dest => dest.GroupType, act => act.Ignore())
                .ForMember(dest => dest.CreationDate, act => act.Ignore());
        }

    }
}
