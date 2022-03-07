
using System.Collections;
using AutoMapper;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DBOs;
using CompanyWebApi.DTOs;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApi.Controllers
{
    public class GroupTypeController : MainController<GroupType, GroupTypeDto>
    {
        public GroupTypeController(CompanyContext context, IMapper mapper) : base(context, mapper)
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
