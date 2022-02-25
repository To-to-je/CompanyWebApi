
using System.Collections;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApi.Controllers
{
    public class GroupTypeController : MainController<GroupType>
    {
        public GroupTypeController(CompanyContext context) : base(context)
        {
        }


        [HttpGet]
        [Route("/[action]")]
        public ActionResult<IEnumerable> GetFrequentGroupTypeAmongAllCustomers()
        {
            return Ok(UnitOfWork.GroupType.GetFrequentGroupTypeAmongAllCustomers());
        }


    }
}
