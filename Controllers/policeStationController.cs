
using Microsoft.AspNetCore.Mvc;


using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WeSafe.Data;
using WeSafe.Models;
using WeSafe.DTO;

namespace Controllers
{
    // [Authorize]

    [ApiController]
    [Route("api/station/new")]
    public class StationController : ControllerBase
    {
        private readonly IRepository<Station> _stationRepository;
        private readonly IMapper _mapper;
        public StationController(IRepository<Station> repo, IMapper mapper)
        {

            _stationRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetPoliceStation()
        {
            Console.WriteLine("Get Police Method invocked");
            var model = await _stationRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<StationDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoliceStation(int id)
        {
            var model = await _stationRepository.GetDataById(id);
            var PoliceStation = _mapper.Map<Station>(model);
            return Ok(PoliceStation);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePoliceStation(StationDto policeStationDto)
        {
            Console.WriteLine("Creating users");
            var PoliceStation = _mapper.Map<Station>(policeStationDto);
            await _stationRepository.InsertData(PoliceStation);
            return Ok(policeStationDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoliceStation(int id)
        {
            var model = await _stationRepository.GetDataById(id);
            var PoliceStation = _mapper.Map<Station>(model);
            await _stationRepository.DeleteData(PoliceStation);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePoliceStation(int id, StationDto policeStationDto)
        {
            Console.WriteLine("update police station method have been invocked");
            var PoliceStation = _mapper.Map<Station>(policeStationDto);
            await _stationRepository.UpdateData(PoliceStation);
            return Ok(User);
        }


    }

}