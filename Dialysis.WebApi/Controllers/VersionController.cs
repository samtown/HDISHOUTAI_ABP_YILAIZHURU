using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dialysis.Service;
using Dialysis.Dto.WebApi.Output;
using Dialysis.Dto.WebApi;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 版本
    /// </summary>
    [Produces("application/json")]
    [Route("api/Version")]
    public class VersionController : Controller
    {
        private readonly SystemService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public VersionController(SystemService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取最新版本信息
        /// </summary>
        /// <param name="versionCode">版本号</param>
        /// <param name="versionType">版本类型（0-医护端，1-患者端）</param>
        /// <returns></returns>
        [HttpGet("LatestVersion/{versionCode}/{versionType}")]
        public async Task<WebApiOutput<GetLatestVersionOutput>> GetLatestVersion(int versionCode, int versionType)
        {
            return WebApiOutput<GetLatestVersionOutput>.Success(await _service.GetLatestVersion(versionCode, versionType));
        }
    }
}