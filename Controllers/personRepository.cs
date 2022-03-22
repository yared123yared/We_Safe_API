using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WeSafe.Data;
using WeSafe.Entity;
using WeSafe.Models;

namespace Controllers{
    [ApiController]
    [Route("api/users")]
    public class PersonController:ControllerBase
    {
        private readonly IRepository<Person> _personRepository;

        private readonly IMapper _mapper;

        public PersonController(IRepository<Person> repo, IMapper mapper){
            _personRepository=repo;
            _mapper=mapper;
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            
            Console.WriteLine("Authentication Method");
            List<Person> persons = await _personRepository.GetData();
            var person= persons.SingleOrDefault(x => x.Phone == model.Phone && x.Password == model.Password);
        
            // return null if user not found
            if (person== null)
                return BadRequest(new { message = "Username or password is incorrect" });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
          
            var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,person.FirstName),
                    new Claim(ClaimTypes.Role,person.Role.RoleName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // user.Token = tokenHandler.WriteToken(token);
            UserEntity userEntity = new UserEntity();
            userEntity.person = person;
            userEntity.Token = tokenHandler.WriteToken(token);
            return Ok(userEntity);
        }
    }
}