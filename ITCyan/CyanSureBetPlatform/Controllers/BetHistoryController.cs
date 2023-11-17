using Cyan.Application.Interfaces;
using Cyan.Domain.Entities;
using Cyan.Utils.Common;
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

        [HttpPost]
        [Route("CreateBetHistory")]
        public async Task<IActionResult> Create(BetHistory model )
        {
            if(model == null)
                BadRequest();

            bool result = await _betHistoryAppService.Create(model);
            string message = result ? "Se creo con exito" : "Ocurrio un error";
            ResponseModel response = new ResponseModel() { Message = message };

            return Ok(response);
        }


    }
}