using CompanyWebApi.Core;
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

        public MainController(Repository<TClass> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            UnitOfWork = unitOfWork;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Add(TClass model)
        {
            await _repository.Add(model);

            return Ok();

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
        public ActionResult<TClass> Get(int id)
        {
            return Ok(_repository.Get(id).Result);
        }
    }
}
