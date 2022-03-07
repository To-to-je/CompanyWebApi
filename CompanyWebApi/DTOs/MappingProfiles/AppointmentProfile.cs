using AutoMapper;
using CompanyWebApi.Core.Domain;

namespace CompanyWebApi.DBOs.MappingProfiles
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
