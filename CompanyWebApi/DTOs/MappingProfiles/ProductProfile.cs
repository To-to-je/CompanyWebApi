using AutoMapper;
using CompanyWebApi.Core.Domain;

namespace CompanyWebApi.DBOs.MappingProfiles
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
