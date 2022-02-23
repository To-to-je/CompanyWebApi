

using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : MainController<Company>
    {


        public CompaniesController(Repository<Company> companyRepository, IUnitOfWork unitOfWork) 
            :base(companyRepository, unitOfWork)
        {
            
        }



        [HttpGet]
        [Route("/[action]")]
        public ActionResult<IEnumerable<Company>> GetCompaniesBenefitedFromAllProducts()
        {
            return Ok(UnitOfWork.Company.GetCompaniesBenefitedFromAllProducts().Result);
        }

        [HttpGet]
        [Route("/[action]")]
        public ActionResult<IEnumerable<Company>> GetCompaniesWithNotInitializedProductionState()
        {
            return Ok(UnitOfWork.Company.GetCompaniesWithNotInitializedProductionState().Result);
        }

        [HttpGet]
        [Route("/[action]")]
        public ActionResult<bool> HasAppointmentForDateRange(DateRange range, int companyId)
        {

            return Ok(UnitOfWork.Company.HasAppointmentForDateRange(range, companyId).Result);

        }


    }

}
