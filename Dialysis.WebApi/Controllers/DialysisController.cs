using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 透析记录
    /// </summary>
    [Produces("application/json")]
    [Route("api/Dialysis")]
    public class DialysisController : Controller
    {
        private readonly DialysisService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public DialysisController(DialysisService service)
        {
            _service = service;
        }

        /// <summary>
        /// 上机详情
        /// </summary>
        /// <param name="id">透析id</param>
        /// <returns>上机详情</returns>
        [HttpGet("On/{id}")]
        public async Task<WebApiOutput<DialysisOnOutput>> GetDialysisOn(long id)
        {
            return await _service.GetDialysisOn(id);
        }

        /// <summary>
        /// 下机详情
        /// </summary>
        /// <param name="id">透析id</param>
        /// <returns>下机详情</returns>
        [HttpGet("Off/{id}")]
        public async Task<WebApiOutput<DialysisOffOutput>> GetDialysisOff(long id)
        {
            return await _service.GetDialysisOff(id);
        }

        /// <summary>
        /// 获取透析列表
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="refreshMode">0-上拉刷新（获取历史数据），1-下拉刷新（获取最新数据）</param>
        /// <param name="id">透析id（可选参数，第一次不用传）</param>
        /// <returns></returns>
        [HttpGet("{patientId}/{pageSize}/{refreshMode}/{id?}")]
        public async Task<WebApiOutput<List<DialysisListOutput>>> GetDialysisList(long patientId, int pageSize, int refreshMode, long? id)
        {
            return await _service.GetDialysisList(patientId, pageSize, refreshMode, id);
        }

        /// <summary>
        /// 透析详情
        /// </summary>
        /// <param name="id">透析id</param>
        /// <returns>透析详情</returns>
        [HttpGet("{id}/Detail")]
        public async Task<WebApiOutput<DialysisDetailOutput>> GetDialysisDetail(long id)
        {
            return await _service.GetDialysisDetail(id);
        }
    }
}