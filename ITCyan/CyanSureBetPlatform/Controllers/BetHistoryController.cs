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
        [Route("CreateBetHistory", Name = BetHistoryResourcesNames.Routes.PostCreate)]
        public async Task<IActionResult> Create(BetHistory model)
        {
            if(model == null)
                BadRequest();

            bool result = await _betHistoryAppService.Create(model);
            string message = result ? "Se creo con exito" : "Ocurrio un error";
            ResponseModel response = new ResponseModel() 
            {
                Message = message,
                Status= result 
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("GetBetHistoryById", Name = BetHistoryResourcesNames.Routes.GetById)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
                BadRequest();

            BetHistory model = await _betHistoryAppService.GetById(id);
            var response = model ?? new BetHistory() { };
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateBetHistory", Name = BetHistoryResourcesNames.Routes.PutUpdate)]
        public async Task<IActionResult> Update(BetHistory model)
        {
            if (model == null)
                BadRequest();

            bool result = await _betHistoryAppService.Update(model);
            string message = result ? "Se acualizo con exito" : "Ocurrio un error";
            ResponseModel response = new ResponseModel() 
            { Message = message, 
              Status = result,
              Key = model.BetHistoryId,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteBetHistory", Name = BetHistoryResourcesNames.Routes.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                BadRequest();

            bool result = await _betHistoryAppService.Delete(id);
            string message = result ? "Se elimino con exito" : "Ocurrio un error";
            ResponseModel response = new ResponseModel() { Message = message };

            return Ok(response);
        }
    }
}