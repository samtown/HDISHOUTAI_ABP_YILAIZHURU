using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 血糖
    /// </summary>
    [Produces("application/json")]
    [Route("api/BloodSugar")]
    public class BloodSugarController : Controller
    {
        private readonly BloodSugarService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public BloodSugarController(BloodSugarService service)
        {
            _service = service;
        }

        /// <summary>
        /// 新增血糖
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="value">血糖值</param>
        /// <returns></returns>
        [HttpPost("{patientId}/{value}")]
        public OutputBase Add(long patientId, decimal value)
        {
            return _service.Add(patientId, value);
        }

        /// <summary>
        /// 获取top数量血糖记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>血糖记录列表</returns>
        [HttpGet("{topNumber}/{patientId}")]
        public async Task<WebApiOutput<List<BloodSugarDto>>> GetTopBloodSugarList(CommonIndexInput input)
        {
            return await _service.GetTopBloodSugarList(input);
        }
    }
}