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
        public async Task<ActionResult> Get()
        {
            var placementsDto = _mapper.Map<IEnumerable<PlacementDto>>(await _placementService.GetPlacementsListAsync());
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
        public async Task<ActionResult> Post([FromBody] PlacementPostModel placement)
        {
            var p = new Placement { WorkerId =  placement.WorkerId, Day = placement.Day, Morning = placement.Morning, Evening = placement.Evening, Night = placement.Night, WardId = placement.WardId};
            return Ok(await _placementService.AddPlacementAsync(p));
        }

        // PUT api/<PlacementController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Placement placement)
        {
            return Ok(await _placementService.UpdatePlacementAsync(id, placement));
        }

        // DELETE api/<PlacementController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _placementService.DeletePlacementAsync(id);
            return Ok();
        }
    }
}
