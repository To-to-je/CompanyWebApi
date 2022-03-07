using AutoMapper;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DBOs;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;

namespace CompanyWebApi.Controllers
{
    public class ProductController : MainController<Product, ProductDto>
    {
        public ProductController(CompanyContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
