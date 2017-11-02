using Dialysis.Dto.WebApi;
using Dialysis.H5.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Threading.Tasks;

namespace Dialysis.H5.Controllers
{
    public class InfomationController : Controller
    {
        private readonly MyOptions _optionsAccessor;

        public InfomationController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 资讯详情
        /// </summary>
        /// <param name="infomationId"></param>
        /// <returns></returns>
        [StaticFileHandlerFilter(Key = "infomationId")]
        [HttpGet]
        public async Task<IActionResult> Detail(long infomationId)
        {
            var request = new RestRequest();
            request.Resource = "/api/Infomation/{infomationId}";
            request.AddParameter("infomationId", infomationId, ParameterType.UrlSegment);

            var api = new DialysisWebApi(_optionsAccessor.BaseUrl);
            var response = await api.ExecuteAsync<WebApiOutput<InfomationDto>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return View(response.ResultValue);
            }
            return View(new InfomationDto());
        }
    }
}