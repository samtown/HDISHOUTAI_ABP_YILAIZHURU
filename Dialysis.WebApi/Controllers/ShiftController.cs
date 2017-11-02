using Dialysis.Dto.Common;
using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 班次
    /// </summary>
    [Produces("application/json")]
    [Route("api/Shift")]
    public class ShiftController : Controller
    {
        private readonly ShiftService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public ShiftController(ShiftService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取医院排班信息
        /// </summary>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        [HttpGet("{hospitalId}")]
        public async Task<WebApiOutput<List<HospitalShiftDto>>> Get(long hospitalId)
        {
            return WebApiOutput<List<HospitalShiftDto>>.Success(await _service.Get(hospitalId));
        }
    }
}