

using AutoMapper;
using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DBOs;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : MainController<Company, CompanyDto>
    {


        public CompanyController(CompanyContext context, IMapper mapper) : base(context, mapper)
        {
            
        }





        [HttpGet]
        [Route("/[action]")]
        public ActionResult<IEnumerable<CompanyDto>> GetCompaniesBenefitedFromAllProducts()
        {
            var entities = UnitOfWork.Company.GetCompaniesBenefitedFromAllProducts().Result;


            return Ok(Mapper.ProjectTo<CompanyDto>(entities).ToList());

        }





        private async Task<IEnumerable<CompanyDto>> GetCompaniesWithNotInitializedProductionStateAsync()
        {
            var entities = UnitOfWork.Company.GetCompaniesWithNotInitializedProductionState();

            return await Mapper.ProjectTo<CompanyDto>(entities).ToListAsync();
        }


        [HttpGet]
        [Route("/[action]")]
        public ActionResult<IEnumerable<Company>> GetCompaniesWithNotInitializedProductionState()
        {
            return Ok(GetCompaniesWithNotInitializedProductionStateAsync().Result);
        }



        [HttpGet]
        [Route("/[action]")]
        public ActionResult<bool> HasAppointmentForDateRange([FromQuery] DateRange range, int companyId)
        {

            return Ok(UnitOfWork.Company.HasAppointmentForDateRange(range, companyId).Result);

        }


    }

}
