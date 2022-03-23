
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
    [Route("api/policeStation")]
    public class PoliceStationController : ControllerBase
    {
        private readonly IRepository<PoliceStation> _policeStationRepository;
        private readonly IMapper _mapper;
        public PoliceStationController(IRepository<PoliceStation> repo, IMapper mapper)
        {

            _policeStationRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetPoliceStation()
        {
            Console.WriteLine("Get Police Method invocked");
            var model = await _policeStationRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<PoliceStationDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoliceStation(int id)
        {
            var model = await _policeStationRepository.GetDataById(id);
            var PoliceStation = _mapper.Map<PoliceStation>(model);
            return Ok(PoliceStation);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePoliceStation(PoliceStationDto policeStationDto)
        {
            Console.WriteLine("Creating users");
            var PoliceStation = _mapper.Map<PoliceStation>(policeStationDto);
            await _policeStationRepository.InsertData(PoliceStation);
            return Ok(policeStationDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoliceStation(int id)
        {
            var model = await _policeStationRepository.GetDataById(id);
            var PoliceStation = _mapper.Map<PoliceStation>(model);
            await _policeStationRepository.DeleteData(PoliceStation);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePoliceStation(int id, PoliceStationDto policeStationDto)
        {
            Console.WriteLine("update police station method have been invocked");
            var PoliceStation = _mapper.Map<PoliceStation>(policeStationDto);
            await _policeStationRepository.UpdateData(PoliceStation);
            return Ok(User);
        }


    }

}