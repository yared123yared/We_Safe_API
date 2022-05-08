
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WeSafe.Data;
using WeSafe.Models;
using WeSafe.DTO;

namespace Controllers
{
    // [Authorize]

    [ApiController]
    [Route("api/case")]
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CaseController : ControllerBase
    {
        private readonly IRepository<Case> _caseRepository;
      
        private readonly IMapper _mapper;
        public CaseController(IRepository<Case> repo, IMapper mapper)
        {

            _caseRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetCases()
        {

            Console.WriteLine("Get Cases Method invocked");

            var model = await _caseRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<CaseDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCase(int id)
        {
            Console.WriteLine("Get Cases Method invocked");
            var model = await _caseRepository.GetDataById(id);
            return Ok(_mapper.Map<CaseDto>(model));
        }
        [HttpPost]
        public async Task<IActionResult> CreatCase(CaseDto caseDto)
        {
            DateTime now = DateTime.Now;
            var Case = _mapper.Map<Case>(caseDto);
            Case.OpenedDate=now;
            await _caseRepository.InsertData(Case);
            return Ok(caseDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var model = await _caseRepository.GetDataById(id);
            var Case = _mapper.Map<Case>(model);
            await _caseRepository.DeleteData(Case);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCase(int id, CaseDto caseDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var Case = _mapper.Map<Case>(caseDto);
            await _caseRepository.UpdateData(Case);
            return Ok(caseDto);
        }


    }

}