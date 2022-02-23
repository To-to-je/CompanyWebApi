using System.Linq.Expressions;
using CompanyWebApi.Core.Domain;

namespace CompanyWebApi.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
            
        Task<IEnumerable<Order>?> GetOrdersWithNotInitializedProductionState();
        Task<IEnumerable<Order>> GetOrdersCloseToDeadline(int numberOfDaysToDeadline);
        Task Change(Order order);

    }

}
