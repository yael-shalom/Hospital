using Hospital.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacementController : ControllerBase
    {
        private readonly IPlacementService _placementService;

        public PlacementController(IPlacementService placementService)
        {
            _placementService = placementService;
        }

        // GET: api/<PlacementController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_placementService.GetPlacementsList());
        }

        // GET api/<PlacementController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string idWorker)
        {
            return Ok(_placementService.GetPlacementById(idWorker));
        }

        // POST api/<PlacementController>
        [HttpPost]
        public ActionResult Post([FromBody] Placement placement)
        {
            return Ok(_placementService.addPlacement(placement));
        }

        // PUT api/<PlacementController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string idWorker, [FromBody] Placement placement)
        {
            return Ok(_placementService.updatePlacement(idWorker, placement));
        }

        // DELETE api/<PlacementController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string idWorker)
        {
            _placementService.deletePlacement(idWorker);
            return Ok();
        }
    }
}
