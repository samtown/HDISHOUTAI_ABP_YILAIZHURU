using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 饮水量接口
    /// </summary>
    [Produces("application/json")]
    [Route("api/Water")]
    public class WaterController : Controller
    {
        private readonly WaterService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public WaterController(WaterService service)
        {
            _service = service;
        }

        /// <summary>
        /// 新增饮水量
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public OutputBase Add([FromBody]AddWaterInput input)
        {
            return _service.Add(input);
        }

        /// <summary>
        /// 获取今日饮水量
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns></returns>
        [HttpGet("{patientId}/Today")]
        public async Task<WebApiOutput<int>> GetTodayDrinkVolume(long patientId)
        {
            return WebApiOutput<int>.Success(await _service.GetTodayDrinkVolume(patientId));
        }
    }
}