
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
    [Route("api/alerts")] 
    public class AlertController : ControllerBase
    {
        private readonly IRepository<Alert> _alertRepository;
        private readonly IMapper _mapper;
        public AlertController(IRepository<Alert> repo, IMapper mapper)
        {

            _alertRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Alerts = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAlerts()
        {
            Console.WriteLine("Get Alert Method invocked");
            var model = await _alertRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<AlertDTO>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlert(int id)
        {
            var model = await _alertRepository.GetDataById(id);
            var alert = _mapper.Map<Alert>(model);
            return Ok(alert);
        }
        [HttpPost]
        public async Task<IActionResult> CreatAlert(AlertDTO alertDTO)
        {
            Console.WriteLine("Creating Alerts");
            var Alert = _mapper.Map<Alert>(alertDTO);
            await _alertRepository.InsertData(Alert);
            return Ok(alertDTO);
        }
        // [Authorize(Alerts = AlertEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            var model = await _alertRepository.GetDataById(id);
            var Alert = _mapper.Map<Alert>(model);
            await _alertRepository.DeleteData(Alert);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlert(int id, AlertDTO alertDTO)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var Alert = _mapper.Map<Alert>(alertDTO);
            await _alertRepository.UpdateData(Alert);
            return Ok(Alert);
        }


    }

}