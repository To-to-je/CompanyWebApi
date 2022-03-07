using AutoMapper;
using CompanyWebApi.Core.Domain;

namespace CompanyWebApi.DBOs.MappingProfiles
{
    public class OrderProfile : Profile
    {

        public OrderProfile()
        {

            CreateMap<Order, OrderDto>()
                .ReverseMap()
                .ForMember(dest => dest.Company, act => act.Ignore())
                .ForMember(dest => dest.Product, act => act.Ignore());

        }

    }
}
