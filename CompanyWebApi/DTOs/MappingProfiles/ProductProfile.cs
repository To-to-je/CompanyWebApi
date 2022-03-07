using AutoMapper;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DTOs;

namespace CompanyWebApi.DTOs.MappingProfiles
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap()
                .ForMember(dest => dest.Orders, act => act.Ignore());

        }

    }
}
