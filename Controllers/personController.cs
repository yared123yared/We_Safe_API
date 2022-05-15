using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WeSafe.Data;
using WeSafe.DTO;
using WeSafe.Entity;
using WeSafe.Models;

namespace Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Police> _policeRepository;

        private readonly IMapper _mapper;
        public PersonController(IRepository<Person> repo, IMapper mapper)
        {
            _personRepository = repo;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {

            Console.WriteLine("Authentication Method");
            List<Person> persons = await _personRepository.GetData();
            var person = persons.SingleOrDefault(x => x.Phone == model.Phone && x.Password == model.Password);

            // return null if user not found
            if (person == null)
                return BadRequest(new { message = "Phone or password is incorrect" });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");

            var tokenDescriptor = new SecurityTokenDescriptor
            {


                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,person.FirstName),
                    new Claim(ClaimTypes.Role,person.Role.Id.ToString())

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // user.Token = tokenHandler.WriteToken(token);
            UserEntity userEntity = new UserEntity();
            PoliceEntity policeEntity = new PoliceEntity();
            if (person.RoleId == 10)
            {
                Console.WriteLine("Person is Community User");
                // return user object
                var user = await _userRepository.GetDataByPhone(model.Phone);
                Console.WriteLine("User" + user);
                userEntity.user = user;
                userEntity.Token = tokenHandler.WriteToken(token);
                return Ok(userEntity);

            }
            else
            {
                Console.WriteLine("Person Police Officer");
                // return police object
                Police police = await _policeRepository.GetDataByPhone(model.Phone);
                Console.WriteLine("Police:" + police);
                policeEntity.police = police;
                policeEntity.Token = tokenHandler.WriteToken(token);
                return Ok(policeEntity);
            }


        }
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            Console.WriteLine("Get Persons Method invocked");
            var model = await _personRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var model = await _personRepository.GetDataById(id);
            var User = _mapper.Map<PersonDto>(model);
            return Ok(User);
        }
        [HttpPost]
        public async Task<IActionResult> CreatPerson(PersonDto personDto)
        {
            Console.WriteLine("Creating roles");
            var User = _mapper.Map<Person>(personDto);
            await _personRepository.InsertData(User);
            return Ok(personDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var model = await _personRepository.GetDataById(id);
            var User = _mapper.Map<Person>(model);
            await _personRepository.DeleteData(User);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, PersonDto personDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var User = _mapper.Map<Person>(personDto);
            await _personRepository.UpdateData(User);
            return Ok(User);
        }
    }
}