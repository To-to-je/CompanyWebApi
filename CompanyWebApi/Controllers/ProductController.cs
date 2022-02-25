using CompanyWebApi.Core.Domain;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;

namespace CompanyWebApi.Controllers
{
    public class ProductController : MainController<Product>
    {
        public ProductController(CompanyContext context) : base(context)
        {
        }

    }
}
