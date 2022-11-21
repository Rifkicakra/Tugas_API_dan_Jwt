using API_dan_JWT.Base;
using API_dan_JWT.Models;
using API_dan_JWT.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_dan_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : BaseController<DivisionRepositories, Division>
    {
        private DivisionRepositories divisionRepositories;

        public DivisionController(DivisionRepositories divisionRepositories) : base(divisionRepositories)
        {
            this.divisionRepositories = divisionRepositories;
        }

        [HttpGet("Name")]
        public ActionResult Get(string name)
        {
            try
            {
                var data = divisionRepositories.Get(name);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ada"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Ada",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}
