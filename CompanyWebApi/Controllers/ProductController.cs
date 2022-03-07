using AutoMapper;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DTOs;
using CompanyWebApi.Persistence;

namespace CompanyWebApi.Controllers
{
    public class ProductController : MainController<Product, ProductDto>
    {
        public ProductController(CompanyContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
