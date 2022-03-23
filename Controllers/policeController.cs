
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
     [Route("api/police")]
    public class PoliceController : ControllerBase
    {
        private readonly IRepository<Police> _policeRepository;
        private readonly IMapper _mapper;
        public PoliceController(IRepository<Police> repo, IMapper mapper)
        {   

            _policeRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetPolice()
        {   
            Console.WriteLine("Get Police Method invocked");
            var model = await _policeRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<PoliceDto>>(model));
        }
        
        [HttpPost]
        public async Task<IActionResult> Createuser(PoliceDto policeDto)
        {
            Console.WriteLine("Creating users");
            var Police= _mapper.Map<Police>(policeDto);
            await _policeRepository.InsertData(Police);
            return Ok(policeDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolice(int id)
        {
            var model = await _policeRepository.GetDataById(id);
            var Police = _mapper.Map<Police>(model);
            await _policeRepository.DeleteData(Police);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolice(int id, PoliceDto policeDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var Police = _mapper.Map<Police>(policeDto);
            await _policeRepository.UpdateData(Police);
            return Ok(User);
        }
       
        
    }

}