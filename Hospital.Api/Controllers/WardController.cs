using Hospital.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }

        // GET: api/<WardController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_wardService.GetWardsList());
        }

        // POST api/<WardController>
        [HttpPost]
        public ActionResult Post([FromBody] Ward ward)
        {
            return Ok(_wardService.AddWard(ward));
        }

        // PUT api/<WardController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ward ward)
        {
            return Ok(_wardService.UpdateWard(id, ward));
        }

        // DELETE api/<WardController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _wardService.DeleteWard(id);
            return Ok();
        }
    }
}
