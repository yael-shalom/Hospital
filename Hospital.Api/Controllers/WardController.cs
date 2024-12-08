using Hospital.Api.Models;
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
        public async Task<ActionResult> Get()
        {
            return Ok(await _wardService.GetWardsListAsync());
        }

        // POST api/<WardController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WardPostModel ward)
        {
            return Ok(await _wardService.AddWardAsync(new Ward { Name = ward.Name}));
        }

        // PUT api/<WardController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Ward ward)
        {
            return Ok(await _wardService.UpdateWardAsync(id, ward));
        }

        // DELETE api/<WardController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _wardService.DeleteWardAsync(id);
            return Ok();
        }
    }
}
