using AutoMapper;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DTOs;

namespace CompanyWebApi.DTOs.MappingProfiles
{
    public class AppointmentProfile : Profile
    {

        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ReverseMap()
                .ForMember(dest => dest.Company, act => act.Ignore());

        }

    }
}
