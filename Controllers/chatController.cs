
// using Microsoft.AspNetCore.Mvc;


// using AutoMapper;

// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using WeSafe.Data;
// using WeSafe.Models;
// using WeSafe.DTO;

// namespace Controllers
// {
//     // [Authorize]

//     [ApiController]
//     [Route("api/chat")]
//     public class ChatController : ControllerBase
//     {
//         [HttpPost("web-rtc-signal")]
//         public async Task<IActionResult> StartCall(WebRtcMessage webRtcMessage)
//         {
//             await _chatService.StartCall(webRtcMessage);
//             return Ok();
//         }

//     }
// }