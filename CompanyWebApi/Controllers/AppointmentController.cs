using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApi.Controllers
{
    public class AppointmentController : MainController<Appointment>
    {
        public AppointmentController(CompanyContext context) : base(context)
        {
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<Company>> GetMostFrequentVisitors(int topNumber)
        {
            return Ok (UnitOfWork.Appointment.GetMostFrequentVisitors(topNumber).Result);
        }



        [HttpGet]
        [Route("[action]")]

        public ActionResult<IEnumerable<string>> GetAllVisitorsForDateRange([FromQuery]DateRange range)
        {
            return Ok(UnitOfWork.Appointment.GetAllVisitorsForDateRange(range).Result);
        }


       
    }
}
