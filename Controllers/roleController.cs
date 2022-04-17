
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
    [Route("api/roles")] 
    public class RoleController : ControllerBase
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IMapper _mapper;
        public RoleController(IRepository<Role> repo, IMapper mapper)
        {

            _roleRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            Console.WriteLine("Get Roles Method invocked");
            var model = await _roleRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<RoleDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var model = await _roleRepository.GetDataById(id);
            var User = _mapper.Map<Role>(model);
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreatRole(RoleDto roleDto)
        {
            Console.WriteLine("Creating roles");
            var Role = _mapper.Map<Role>(roleDto);
            await _roleRepository.InsertData(Role);
            return Ok(roleDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var model = await _roleRepository.GetDataById(id);
            var Role = _mapper.Map<Role>(model);
            await _roleRepository.DeleteData(Role);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleDto roleDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var Role = _mapper.Map<Role>(roleDto);
            await _roleRepository.UpdateData(Role);
            return Ok(Role);
        }


    }

}