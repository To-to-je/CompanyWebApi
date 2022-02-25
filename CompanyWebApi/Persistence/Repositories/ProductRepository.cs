using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CompanyWebApi.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        protected CompanyContext? CompanyContext => Context as CompanyContext;

        public async Task<IEnumerable> GetTopSellingProducts(int topNumber)
        {
            if (CompanyContext?.Orders != null && CompanyContext.Products != null)
            {
                var productsSold = CompanyContext?.Orders
                    .Select(order => order.Product!)
                    .GroupBy(p => p)
                    .Select(product => new
                    {
                        Product = product.Key.ProductCode,
                        Counts = product.Count()
                    })
                    .OrderByDescending(product => product.Counts)
                    .Take(topNumber);

               return await productsSold!.ToListAsync();
                
            }

            else
            {
                throw new NullReferenceException("There are no orders or products in database");
            }
        }

        public async Task<IEnumerable<Product>> GetProductsSoldInDateRange(DateRange range)
        {
            if (CompanyContext?.Orders != null && CompanyContext?.Products != null)
            {
                var productsSoldInCurrentDateRange = await CompanyContext?.Orders
                    .Where(o => o.DateOfOrder >= range.Start && o.DateOfOrder <= range.End)
                    .Select(o => o.Product!)
                    .ToListAsync()!;
                return productsSoldInCurrentDateRange!;
            }
            else
            {
                throw new NullReferenceException("There are no orders or products in database");
            }
        }

        public async Task<int?>  GetNumberOfSpecificProductSoldInPeriod(DateRange range, int productId)
        {
            if (CompanyContext?.Orders != null && CompanyContext?.Products != null)
            {
                var count = await CompanyContext?.Orders
                    .Where(o => o.Product != null && o.ProductId == productId && o.DateOfOrder >= range.Start && o.DateOfOrder <= range.End)
                    .Select(o => o)
                    .CountAsync()!;
                return count;
            }
            else
            {
                throw new NullReferenceException("There are no orders or products in database");
            }
        }

        public async Task Change(Product product)
        {
            if (CompanyContext?.Products != null)
            {
                var productInDatabase = await CompanyContext?.Products.FirstOrDefaultAsync(p => p.ProductCode == product.ProductCode)!;

                if (productInDatabase != null)
                {
                    productInDatabase.Name = product.Name;
                }
                else
                {
                    throw new NullReferenceException();
                }


            }
        }
    }
}
