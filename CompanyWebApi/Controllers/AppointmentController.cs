using CompanyWebApi.Core.Domain;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApi.Controllers
{
    public class AppointmentController : MainController<Appointment>
    {
        public AppointmentController(Repository<Appointment> appointmentRepository, UnitOfWork unitOfWork)
            :base(appointmentRepository, unitOfWork)
        {
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<Company>> GetMostFrequentVisitors(int topNumber)
        {
            return Ok (UnitOfWork.Appointment.GetMostFrequentVisitors(topNumber).Result);
        }


    }
}
