using API_dan_JWT.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API_dan_JWT.Base
{
    [Route("api/[controller]")]
    [ApiController]

    public class BaseController<Repository, Entity> : ControllerBase
    where Repository : class, IRepository<Entity>
    where Entity : class
    {
        Repository _repository;

        public BaseController(Repository repository)
            {
             _repository = repository;
            }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _repository.Get();
            return Ok(new {message ="Data has been Retrieved", StatusCode = 200, data = data});

        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var data = _repository.Get(id);
            return Ok(new { message = "Data has been Retrieved", StatusCode = 200, data = data });
        }

        [HttpPost]
        public IActionResult Post(Entity entity)
        {
            var data = _repository.Create(entity);
            return Ok(new { message = "Data has been Created", StatusCode = 200, data = data });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _repository.Delete(id);
            return Ok(new { message = "Data has been Deleted", StatusCode = 200, data = data });
        }

        [HttpPut]
        public IActionResult Update(Entity entity)
        {
            var data = _repository.Update(entity);
            return Ok(new { message = "Data has been Deleted", StatusCode = 200, data = data });
        }
    }        
}

