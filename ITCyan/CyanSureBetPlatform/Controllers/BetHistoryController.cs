using Cyan.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CyanSureBetPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetHistoryController : ControllerBase
    {
        private readonly IBetHistoryAppService _betHistoryAppService;
        public BetHistoryController(IBetHistoryAppService betHistoryAppService) {
        _betHistoryAppService = betHistoryAppService;
        }

        [HttpGet]
        [Route("GetAllHistory")]
        public async Task<IActionResult> GetAllHistory()
        {
            var list = await _betHistoryAppService.GetList();

            return Ok(list);
        }


    }
}