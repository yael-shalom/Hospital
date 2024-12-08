using Hospital.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        // GET: api/<Worker>
        [HttpGet]
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
        public async Task<ActionResult> Post([FromBody] Worker worker)
        {
            return Ok(await _workerService.AddWorkerAsync(worker));
        }

        // PUT api/<Worker>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Worker worker)
        {
            return Ok(await _workerService.UpdateWorkerAsync(id,worker));
        }

        // DELETE api/<Worker>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _workerService.DeleteWorkerAsync(id);
            return Ok();
        }
    }
}
