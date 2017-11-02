using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 资讯
    /// </summary>
    [Produces("application/json")]
    [Route("api/Infomation")]
    public class InfomationController : Controller
    {
        private readonly InfomationService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public InfomationController(InfomationService service)
        {
            _service = service;
        }

        /// <summary>
        /// 根据资讯Id获取资讯详情
        /// </summary>
        /// <param name="infomationId">资讯Id</param>
        /// <returns>资讯详情</returns>
        [HttpGet("{infomationId}")]
        public async Task<WebApiOutput<InfomationDto>> GetInfomationById(long infomationId)
        {
            return await _service.GetInfomationById(infomationId);
        }

        /// <summary>
        /// 获取首页轮播资讯
        /// </summary>
        /// <returns>轮播资讯列表</returns>
        [HttpGet("Slide")]
        public async Task<WebApiOutput<List<InfomationDto>>> GetHomePageSlideInfomationList()
        {
            return await _service.GetHomePageSlideInfomationList();
        }
    }
}