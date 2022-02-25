using CompanyWebApi.Core.Domain;
using System.Collections;

namespace CompanyWebApi.Core.Repositories
{
    public interface IGroupTypeRepository : IRepository<GroupType>
    {
        Task<IEnumerable> GetFrequentGroupTypeAmongAllCustomers();
        Task Change(GroupType groupType);
    }
}
