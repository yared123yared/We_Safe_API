
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WeSafe.Data;
using WeSafe.Models;
using WeSafe.DTO;

namespace Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IMapper _mapper;
        public UserController(IRepository<User> repo, IRepository<Role> roleRepo, IMapper mapper)
        {

            _userRepository = repo;
            _roleRepository = roleRepo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            Console.WriteLine("Get Users Method invocked");
            var model = await _userRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var model = await _userRepository.GetDataById(id);
            var User = _mapper.Map<User>(model);
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> Createuser(UserDto userDto)
        {

            Console.WriteLine("Creating users");
            var User = _mapper.Map<User>(userDto);
            Role role = await _roleRepository.GetDataById(userDto.RoleId);
            User.Person.Role=role;
            await _userRepository.InsertData(User);
            return Ok(userDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var model = await _userRepository.GetDataById(id);
            var User = _mapper.Map<User>(model);
            await _userRepository.DeleteData(User);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var User = _mapper.Map<User>(userDto);
            await _userRepository.UpdateData(User);
            return Ok(User);
        }


    }

}