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

        public async Task<IQueryable<Company>> GetCompaniesBenefitedFromAllProducts()
        {

            if (CompanyContext?.Products != null && CompanyContext.Companies != null)
            {
                var totalNumberOfAvailableProducts = await CompanyContext.Products
                    .Select(x => x).CountAsync();

                return CompanyContext.Companies.
                    Where(c => c.Orders != null && c.Orders
                        .Distinct().Count() == totalNumberOfAvailableProducts)
                    .Select(c => c);
            }
            else
            {
                throw new ArgumentNullException();
            }

        }

        public IQueryable<Company> GetCompaniesWithNotInitializedProductionState()
        {
            if (CompanyContext?.Companies != null)
            {

                return CompanyContext.Companies
                    .Where(c => c.Orders != null && c.Orders
                        .Any(o => DateTime.Compare(o.DateOfCompanyProductionStateInitialization, DateTime.Now) > 0))
                    .Select(c => c);

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
                var companyInDatabase = await CompanyContext?.Companies.FirstOrDefaultAsync(c => c.Id == company.Id)!;

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
