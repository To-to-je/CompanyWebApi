using AutoMapper;
using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.DBOs;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApi.Controllers
{
    public class AppointmentController : MainController<Appointment, AppointmentDto>
    {
        public AppointmentController(CompanyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<CompanyDto>> GetMostFrequentVisitors(int topNumber)
        {
            var entity = UnitOfWork.Appointment.GetMostFrequentVisitors(topNumber).Result;
            return Ok (Mapper.ProjectTo<CompanyDto>(entity).ToList());
        }



        [HttpGet]
        [Route("[action]")]

        public ActionResult<IEnumerable<string>> GetAllVisitorsForDateRange([FromQuery]DateRange range)
        {
            return Ok(UnitOfWork.Appointment.GetAllVisitorsForDateRange(range).Result);
        }


       
    }
}
