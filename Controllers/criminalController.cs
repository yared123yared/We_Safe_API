
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WeSafe.Data;
using WeSafe.Models;
using WeSafe.DTO;

namespace Controllers
{
    // [Authorize]

    [ApiController]
    [Route("api/criminal")]
    public class CriminalController : ControllerBase
    {
        private readonly IRepository<Criminal> _criminallRepository;
        private readonly IMapper _mapper;
        public CriminalController(IRepository<Criminal> repo, IMapper mapper)
        {

            _criminallRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetCriminals()
        {
            Console.WriteLine("Get Criminal Method invocked");
            var model = await _criminallRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<CriminalDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCriminal(int id)
        {
            var model = await _criminallRepository.GetDataById(id);
            var Criminal = _mapper.Map<Criminal>(model);
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreatCriminal(CriminalDto criminalDto)
        {
            Console.WriteLine("Creating criminal");
            var Criminal = _mapper.Map<Criminal>(criminalDto);
            await _criminallRepository.InsertData(Criminal);
            return Ok(criminalDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var model = await _criminallRepository.GetDataById(id);
            var Criminal = _mapper.Map<Criminal>(model);
            await _criminallRepository.DeleteData(Criminal);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, CriminalDto criminalDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var Criminal = _mapper.Map<Criminal>(criminalDto);
            await _criminallRepository.UpdateData(Criminal);
            return Ok(Criminal);
        }


    }

}