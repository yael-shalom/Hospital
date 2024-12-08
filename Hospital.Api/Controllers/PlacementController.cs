using AutoMapper;
using Hospital.Api.Models;
using Hospital.Core.DTOs;
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
        private readonly IMapper _mapper;

        public PlacementController(IPlacementService placementService, IMapper mapper)
        {
            _placementService = placementService;
            _mapper = mapper;
        }

        // GET: api/<PlacementController>
        [HttpGet]
        public ActionResult Get()
        {
            var placementsDto = _mapper.Map<IEnumerable<PlacementDto>>(_placementService.GetPlacementsList());
            return Ok(placementsDto);
        }

        // GET api/<PlacementController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var p = _placementService.GetPlacementById(id);
            if (p == null)
            {
                return NotFound();
            }
            var placementDto = _mapper.Map<PlacementDto>(p);
            return Ok(placementDto);
        }

        // POST api/<PlacementController>
        [HttpPost]
        public ActionResult Post([FromBody] PlacementPostModel placement)
        {
            var p = new Placement { WorkerId =  placement.WorkerId, Day = placement.Day, Morning = placement.Morning, Evening = placement.Evening, Night = placement.Night, WardId = placement.WardId};
            return Ok(_placementService.AddPlacement(p));
        }

        // PUT api/<PlacementController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Placement placement)
        {
            return Ok(_placementService.UpdatePlacement(id, placement));
        }

        // DELETE api/<PlacementController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _placementService.DeletePlacement(id);
            return Ok();
        }
    }
}
