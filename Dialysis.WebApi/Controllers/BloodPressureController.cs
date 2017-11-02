using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 透析血压
    /// </summary>
    [Produces("application/json")]
    [Route("api/BloodPressure")]
    public class BloodPressureController : Controller
    {
        private readonly BloodPressureService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public BloodPressureController(BloodPressureService service)
        {
            _service = service;
        }

        /// <summary>
        /// 新增血压
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public OutputBase Add([FromBody]AddBloodPressureInput input)
        {
            return _service.Add(input);
        }

        /// <summary>
        /// 获取top数量血压记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>血压记录列表</returns>
        [HttpGet("{topNumber}/{patientId}")]
        public async Task<WebApiOutput<List<BloodPressureDto>>> GetTopBloodPressureList(CommonIndexInput input)
        {
            return await _service.GetTopBloodPressureList(input);
        }
    }
}