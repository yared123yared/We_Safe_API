
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
    [Route("api/news")] 
    public class NewsController : ControllerBase
    {
        private readonly IRepository<News> _newsRepository;
        private readonly IMapper _mapper;
        public NewsController(IRepository<News> repo, IMapper mapper)
        {

            _newsRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            Console.WriteLine("Get news Method invocked");
            var model = await _newsRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<NewsDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewSingleNews(int id)
        {
            var model = await _newsRepository.GetDataById(id);
            var news = _mapper.Map<News>(model);
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreatNews(NewsDto NewsDto)
        {
            Console.WriteLine("Creating Newss");
            var News = _mapper.Map<News>(NewsDto);
            await _newsRepository.InsertData(News);
            return Ok(NewsDto);
        }
        // [Authorize(Newss = NewsEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var model = await _newsRepository.GetDataById(id);
            var News = _mapper.Map<News>(model);
            await _newsRepository.DeleteData(News);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNews(int id, NewsDto NewsDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var News = _mapper.Map<News>(NewsDto);
            await _newsRepository.UpdateData(News);
            return Ok(News);
        }


    }

}