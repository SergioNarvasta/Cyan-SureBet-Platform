using Cyan.WebAPI.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;

namespace CyanSureBetPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapperController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllHistory", Name = BetHistoryResourcesNames.Routes.GetQuery)]
        //[ResponseType(typeof(RepresentationCollectionPaged<PaymentMethodListRp>))]
        public async Task<IActionResult> GetScraper(int HouseBetId)
        {
            // Get the HouseBet By Id 
            // Get the Url and Scraping the web
            // Get the data by selectors
            // Storage the data
            string HouseBetUrl = "https://www.betsson.com/pe/apuestas-deportivas"; //_houseBetAppService.GetById(HouseBetId);

            var web = new HtmlWeb();
            // loading the target web page 
            var document = web.Load(HouseBetUrl);


            return Ok();
        }
    }
}
