using CompanyWebApi.Core.Domain;
using CompanyWebApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public CompanyContext? CompanyContext => Context as CompanyContext;

        public OrderRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>?> GetOrdersWithNotInitializedProductionState()
        {
            if (CompanyContext?.Orders != null)
            {
                var notInitializedProduction = await CompanyContext?.Orders
                    .Where(o => o.DateOfCompanyProductionStateInitialization == null)
                    .Select(o => o)
                    .ToListAsync()!;
                return notInitializedProduction;
            }
            else
            {
                throw new NullReferenceException("No Orders in Database");
            }

        }

        public async Task<IEnumerable <Order>> GetOrdersCloseToDeadline(int numberOfDaysToDeadline)
        {
            var deadlineLimit =DateTime.Today + TimeSpan.FromDays((double)numberOfDaysToDeadline);

            if (CompanyContext?.Orders != null)
                return await CompanyContext.Orders
                    .Where(o => o.DateWhenContractWillExpire != null &&
                                o.DateWhenContractWillExpire <= deadlineLimit.Date)
                    .Select(o => o)
                    .ToListAsync();

            else throw new NullReferenceException("No orders in database!");
        }

        public async Task Change(Order order)
        {
            if (CompanyContext?.Orders != null)
            {
                var orderInDatabase = await CompanyContext?.Orders.FirstOrDefaultAsync(o => o.OrderId == order.OrderId)!;

                if (orderInDatabase != null)
                {
                    orderInDatabase.DateOfOrder = order.DateOfOrder;
                    orderInDatabase.CompanyId = order.CompanyId;
                    orderInDatabase.DateWhenContractWillExpire = order.DateWhenContractWillExpire;
                    orderInDatabase.DateOfCompanyProductionStateInitialization =
                        orderInDatabase.DateOfCompanyProductionStateInitialization;

                }
                else
                {
                    throw new NullReferenceException();
                }


            }
        }
    }
}
