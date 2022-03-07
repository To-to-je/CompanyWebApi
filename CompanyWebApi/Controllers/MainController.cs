using AutoMapper;
using CompanyWebApi.Core;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController<TClass, TClassDto> : ControllerBase
        where TClass : class, new()
        where TClassDto : class, new()

    {
        private readonly Repository<TClass> _repository;
        protected readonly IMapper Mapper;
        protected readonly UnitOfWork UnitOfWork;

        public MainController(CompanyContext context, IMapper mapper)
        {
            _repository = new Repository<TClass>(context);
            UnitOfWork = new UnitOfWork(context);
            Mapper = mapper;
        }   


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Add([FromQuery] TClassDto modelDbo)
        {

            TClass model = Mapper.Map<TClass>(modelDbo);

            await _repository.Add(model);

            await UnitOfWork.Complete();


            return Ok();

        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddRange([FromQuery] IEnumerable<TClassDto> entitiesDbo)
        {
            List<TClass> entities = new();

            foreach (var entityDbo in entitiesDbo)
            {
                entities.Add(Mapper.Map<TClass>(entityDbo));
            }

            await _repository.AddRange(entities);
            await UnitOfWork.Complete();

            return Ok();
        }


        private async Task<List<TClassDto>> GetAllAsync()
        {

            var listOfEntities = _repository.GetAll();

            var listOfDboEntities = await Mapper.ProjectTo<TClassDto>(listOfEntities).ToListAsync();

            return listOfDboEntities;

        }


        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<TClassDto>> GetAll()
        {

            return Ok(GetAllAsync().Result);

        }



        [HttpGet]
        [Route("[action]")]
        public ActionResult<TClassDto> Get([FromQuery] int id)
        {

            var entity = _repository.Get(id).Result;
            var dboEntity = Mapper.Map<TClassDto>(entity);

            return Ok(dboEntity);

        }



        [HttpDelete]
        [Route("[action]")]
        public async Task<ActionResult> Remove([FromQuery] int id)
        {
            await _repository.Remove(id);
            await UnitOfWork.Complete();
            return Ok();

        }

    }
}
