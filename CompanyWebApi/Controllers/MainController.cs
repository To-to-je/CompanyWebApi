using CompanyWebApi.Core;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController<TClass> : ControllerBase where TClass : class, new()
    {
        private readonly Repository<TClass> _repository;
        protected readonly IUnitOfWork UnitOfWork;

        public MainController(CompanyContext context)
        {
            _repository = new Repository<TClass>(context);
            UnitOfWork = new UnitOfWork(context);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Add([FromQuery] TClass model)
        {
            await _repository.Add(model);

            return Ok();

        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult AddRange([FromQuery] IEnumerable<TClass> entities)
        {
            return Ok(_repository.AddRange(entities).Result);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<TClass>> GetAll()
        {

            var listOfEntities = _repository.GetAll().Result;

            return Ok(listOfEntities);

        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<TClass> Get([FromQuery] int id)
        {
            return Ok(_repository.Get(id).Result);
        }


        [HttpDelete]
        [Route("[action]")]
        public ActionResult<TClass> Remove([FromQuery] int id)
        {
            return Ok(_repository.Remove(id));
        }

    }
}
