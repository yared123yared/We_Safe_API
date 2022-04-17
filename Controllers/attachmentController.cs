
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
    [Route("api/attachments")]
    public class AttachmentController : ControllerBase
    {
        private readonly IRepository<Attachment> _attachmentRepository;
        private readonly IMapper _mapper;
        public AttachmentController(IRepository<Attachment> repo, IMapper mapper)
        {

            _attachmentRepository = repo;
            _mapper = mapper;
        }
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAttachments()
        {
            Console.WriteLine("Get Attachment Method invocked");
            var model = await _attachmentRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<AttachmentDto>>(model));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttachment(int id)
        {
            var model = await _attachmentRepository.GetDataById(id);
            var attachment = _mapper.Map<Attachment>(model);
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreatAttachment(AttachmentDto attachmentDto)
        {
            Console.WriteLine("Creating attachment");
            var attachment = _mapper.Map<Attachment>(attachmentDto);
            await _attachmentRepository.InsertData(attachment);
            return Ok(attachmentDto);
        }
        // [Authorize(Roles = RoleEntity.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            var model = await _attachmentRepository.GetDataById(id);
            var attachment = _mapper.Map<Attachment>(model);
            await _attachmentRepository.DeleteData(attachment);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttachment(int id, AttachmentDto roleDto)
        {
            // Console.WriteLine(technician.AccepteStatus);
            var attachment = _mapper.Map<Attachment>(roleDto);
            await _attachmentRepository.UpdateData(attachment);
            return Ok(attachment);
        }


    }

}