using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionStatistics.Application.Models;
using MissionStatistics.Application.Services;

namespace MissionStatistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly IMissionService _service;
        private readonly IGeocodingService _geocodingService;

        public MissionsController(IMissionService service, IGeocodingService geocodingService)
        {
            _service = service;
            _geocodingService = geocodingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MissionDto>>> GetAllMissions()
        {
            var missions = await _service.GetAllMissions();
            return Ok(missions);
        }

        [HttpGet("{id}", Name = nameof(GetMission))]
        public async Task<ActionResult<MissionDto>> GetMission(int id)
        {
            var mission = await _service.GetMission(id);
            if (mission == null)
            {
                return NotFound();
            }

            return Ok(mission);
        }

        [HttpGet(nameof(GetMostIsolatedCountry))]
        public async Task<IActionResult> GetMostIsolatedCountry()
        {
            var (country, isolatedAgents) = await _service.GetMostIsolatedCountry();
            if (string.IsNullOrEmpty(country) || isolatedAgents == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                result = $"{country} with an isolation degree of {isolatedAgents}"
            });
        }



        [HttpPost("find-closet")]
        public async Task<ActionResult<MissionDto?>> FindCloset(Location location)
        {
            var closetMission = await _service.GetClosetMission(location);
            if (closetMission == null)
            {
                return NotFound();
            }
            return Ok(closetMission);

        }


        [HttpPost]
        public async Task<ActionResult<MissionDto>> AddMission(CreateMissionDto missionDto)
        {
            var mission = await _service.AddMission(missionDto);
            return CreatedAtRoute(nameof(GetMission), new { id = mission.Id }, mission);

        }







    }
}
