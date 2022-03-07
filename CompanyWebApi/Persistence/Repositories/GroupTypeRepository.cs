using CompanyWebApi.Core.Domain;
using CompanyWebApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CompanyWebApi.Persistence.Repositories
{
    public class GroupTypeRepository : Repository<GroupType>, IGroupTypeRepository
    {

        CompanyContext? CompanyContext => Context as CompanyContext;

        public GroupTypeRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable>  GetFrequentGroupTypeAmongAllCustomers()
        {
            if (CompanyContext?.GroupTypes != null)
            {
                var frequentGroupType = await CompanyContext?.GroupTypes
                    .Where(g => g.Companies != null)
                    .Select(group => new
                    {
                        GroupName = group.Type,

                        NumberOfCompanies = group.Companies!.Count
                    })
                    .OrderByDescending(group => group.NumberOfCompanies)
                    .Take(CompanyContext.GroupTypes.Count())
                    .ToListAsync()!;
                return frequentGroupType;

            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task Change(GroupType groupType)
        {
            if (CompanyContext?.GroupTypes != null)
            {
                var groupTypeInDatabase = await CompanyContext?.GroupTypes.FirstOrDefaultAsync(g => g.Id == groupType.Id)!;

                if (groupTypeInDatabase != null)
                {
                    
                    groupTypeInDatabase.Type = groupType.Type;

                }
                else
                {
                    throw new NullReferenceException();
                }

            }
        }
    }
}
