using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyContext context) : base(context)
        {
        }

        public CompanyContext? CompanyContext => Context as CompanyContext;

        public async Task<IEnumerable<Company>> GetCompaniesBenefitedFromAllProducts()
        {

            if (CompanyContext?.Products != null && CompanyContext.Companies != null)
            {
                var totalNumberOfAvailableProducts = CompanyContext.Products
                    .Select(x => x).Count();

                return await CompanyContext.Companies.
                    Where(c => c.Orders != null && c.Orders
                        .Sum(o => o.NumberOfProducts) == totalNumberOfAvailableProducts)
                    .Select(c => c).ToListAsync();
            }
            else
            {
                throw new ArgumentNullException();
            }

        }

        public async Task<IEnumerable<Company>> GetCompaniesWithNotInitializedProductionState()
        {
            if (CompanyContext?.Companies != null)
            {

                return await CompanyContext.Companies
                    .Where(c => c.Orders != null && c.Orders
                        .Any(o => o.DateOfCompanyProductionStateInitialization == null)
                    ).ToListAsync();

            }
            else
            {
                throw new NullReferenceException("No companies registered in database");
            };
        }

        public async Task<bool> HasAppointmentForDateRange(DateRange range, int companyId)
        {
            if (CompanyContext?.Companies != null)
            {
                var currentCompany = await CompanyContext?.Companies.FirstOrDefaultAsync(c => c.Id == companyId)!;


                if (currentCompany != null)
                {
                    bool check;
                    if (currentCompany.Appointments != null)
                    {
                        check = currentCompany.Appointments
                            .Where(a => a.AppointmentDate >= range.Start && a.AppointmentDate <= range.End)
                            .Any(a => true);
                    }
                    else
                    {
                        check = false;
                    }

                    return check;
                }
                else
                {
                    throw new NullReferenceException("There is no such company");
                }
            }
            else
            {
                throw new NullReferenceException("There are no companies in Database");
            }
        }

        public async Task Change(Company company)
        {
            if (CompanyContext?.Companies != null)
            {
                var companyInDatabase = await CompanyContext?.Companies.FirstOrDefaultAsync(c=>c.Id == company.Id)!;

                if (companyInDatabase != null)
                {
                    companyInDatabase.GroupType = company.GroupType;
                    companyInDatabase.Name = company.Name;
                }
                else
                {
                    throw new NullReferenceException();
                }


            }
        }

        
    }
}
