using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CyanSureBetPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetHistoryController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllHistory")]
        public async Task<IActionResult> GetAllHistory()
        {
            return Ok("Test");
        }
    }
}
