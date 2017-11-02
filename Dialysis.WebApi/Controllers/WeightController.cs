using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 体重
    /// </summary>
    [Produces("application/json")]
    [Route("api/Weight")]
    public class WeightController : Controller
    {
        private readonly WeightService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public WeightController(WeightService service)
        {
            _service = service;
        }

        /// <summary>
        /// 新增体重
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OutputBase> Add([FromBody]AddWeightInput input)
        {
            return await _service.Add(input);
        }

        /// <summary>
        /// 获取top数量体重记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>体重记录列表</returns>
        [HttpGet("{topNumber}/{patientId}")]
        public async Task<WebApiOutput<List<WeightDto>>> GetTopWeightList(CommonIndexInput input)
        {
            return await _service.GetTopWeightList(input);
        }
    }
}