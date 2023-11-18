using Cyan.Application.Interfaces;
using Cyan.Domain.Entities;
using Cyan.Utils.Common;
using Cyan.WebAPI.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

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
        [Route("GetAllHistory",Name = BetHistoryResourcesNames.Routes.GetQuery)]
        //[ResponseType(typeof(RepresentationCollectionPaged<PaymentMethodListRp>))]
        public async Task<IActionResult> GetList(int pageSize=20,int pageIndex=1,string filter="")
        {
            var list = await _betHistoryAppService.GetList(pageSize,pageIndex,filter);

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

        [HttpPost]
        [Route("GetBetHistoryById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
                BadRequest();

            var model = await _betHistoryAppService.GetById(id);
            return Ok(model);
        }

    }
}