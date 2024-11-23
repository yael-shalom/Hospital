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
        public ActionResult Get()
        {
            return Ok(_workerService.GetWorkersList());
        }

        // GET api/<Worker>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            return Ok(_workerService.GetWorkerById(id));
        }

        // POST api/<Worker>
        [HttpPost]
        public ActionResult Post([FromBody] Worker worker)
        {
            return Ok(_workerService.AddWorker(worker));
        }

        // PUT api/<Worker>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Worker worker)
        {
            return Ok(_workerService.UpdateWorker(id,worker));
        }

        // DELETE api/<Worker>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _workerService.DeleteWorker(id);
            return Ok();
        }
    }
}
