using System.Collections;
using System.Linq.Expressions;
using CompanyWebApi.Core.Domain;

namespace CompanyWebApi.Core.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable> GetTopSellingProducts(int topNumber);

        Task<IEnumerable<Product>> GetProductsSoldInDateRange(DateRange range);

        Task<int?> GetNumberOfSpecificProductSoldInPeriod(DateRange range, int productId);
        Task Change(Product product);

    }
}
