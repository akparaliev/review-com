using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReviewCom.Services;
using ReviewComDAL;
using ReviewComDAL.Models;

namespace ReviewCom.Controllers
{
    [Route("api/[version]/[controller]")]
    [ApiController]
    public abstract class AbstractController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository repository;
        protected readonly ILoggingService loggingService;

        public AbstractController(TRepository repository, ILoggingService loggingService)
        {
            this.repository = repository;
            this.loggingService = loggingService;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<List<TEntity>>> GetAll()
        {
            loggingService.LogInformation(string.Format("Get all of {0} entries from DB", typeof(TEntity).Name));
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await repository.Get(id);
            if (entity == null)
            {
                loggingService.LogError(string.Format("{0} entity with id = {1} is not found", typeof(TEntity).Name, id));
                return NotFound();
            }

            return entity;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                loggingService.LogError(string.Format("{0} entity with id = {1} does not allow updating identifier", typeof(TEntity).Name, id));
                return BadRequest();
            }

            await repository.Update(entity);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await repository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await repository.Delete(id);
            if (entity == null)
            {
                loggingService.LogError(string.Format("{0} entity with id = {1} is not found", typeof(TEntity).Name, id));
                return NotFound();
            }

            return entity;
        }

    }
}