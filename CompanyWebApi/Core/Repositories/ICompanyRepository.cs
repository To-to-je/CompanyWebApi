
using CompanyWebApi.Core.Domain;


namespace CompanyWebApi.Core.Repositories
{
    public interface ICompanyRepository:IRepository<Company>
    {
       
        Task<IEnumerable<Company>> GetCompaniesBenefitedFromAllProducts();
        Task<IEnumerable<Company>> GetCompaniesWithNotInitializedProductionState();
        Task<bool> HasAppointmentForDateRange(DateRange range, int companyId);
        Task Change(Company company);

    }
}  
