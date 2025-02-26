using Hospital.Api.Models;
using Hospital.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        // GET: api/<Worker>
        [HttpGet]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _workerService.GetWorkersListAsync());
        }

        // GET api/<Worker>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            return Ok(_workerService.GetWorkerById(id));
        }

        // POST api/<Worker>
        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult> Post([FromBody] Worker worker)
        {
            var w = await _workerService.AddWorkerAsync(worker);
            if(w != null) 
                return Ok(w);
            return BadRequest("invalid parameter/s");
        }

        // PUT api/<Worker>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult> Put(string id, [FromBody] WorkerPostModel worker)
        {
            return Ok(await _workerService.UpdateWorkerAsync(id,new Worker { Id = id, Name = worker.Name, Role = Enum.Parse<eRole>(worker.Role) }));
        }

        // DELETE api/<Worker>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult> Delete(string id)
        {
            await _workerService.DeleteWorkerAsync(id);
            return Ok();
        }
    }
}
