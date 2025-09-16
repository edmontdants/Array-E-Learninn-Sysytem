using Microsoft.AspNetCore.Mvc;

namespace ArrayELearnApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage(string toUserId, string message)
        {
            return Ok();
        }
    }
}
