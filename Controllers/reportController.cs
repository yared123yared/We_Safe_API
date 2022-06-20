
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
    [Route("api/reports")] 
    public class ReportController : ControllerBase
    {
        private readonly IRepository<Report> _reportRepository;
        private readonly IMapper _mapper;
        public ReportController(IRepository<Report> repo, IMapper mapper)
        {

            _reportRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            Console.WriteLine("Get Reports Method invocked");
            var model = await _reportRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<ReportDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport(int id)
        {
            var model = await _reportRepository.GetDataByUserId(id);
            // var report = _mapper.Map<Report>(model);
       return Ok(_mapper.Map<IEnumerable<ReportDto>>(model));
        }
        [HttpPost]
        public async Task<IActionResult> CreatReport(ReportDto reportDto)
        {
            Console.WriteLine("Creating reports");
            var report = _mapper.Map<Report>(reportDto);
            await _reportRepository.InsertData(report);
            return Ok(reportDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var model = await _reportRepository.GetDataById(id);
            var report = _mapper.Map<Report>(model);
            await _reportRepository.DeleteData(report);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReport(int id, ReportDto reportDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var report = _mapper.Map<Report>(reportDto);
            await _reportRepository.UpdateData(report);
            return Ok(report);
        }


    }

}