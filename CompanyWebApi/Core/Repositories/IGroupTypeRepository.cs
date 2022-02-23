using System.Collections;
using CompanyWebApi.Core.Domain;

namespace CompanyWebApi.Core.Repositories
{
    public interface IGroupTypeRepository:IRepository<GroupType>
    {
        Task<IEnumerable> GetFrequentGroupTypeAmongAllCustomers();
        Task Change(GroupType groupType);
    }
}
