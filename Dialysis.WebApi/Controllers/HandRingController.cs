using Dialysis.Dto.WebApi;
using Dialysis.Dto.WebApi.Input;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 手环
    /// </summary>
    [Produces("application/json")]
    [Route("api/HandRing")]
    public class HandRingController : Controller
    {
        private readonly HandRingService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public HandRingController(HandRingService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加手环数据
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OutputBase> Add([FromBody]AddHandRingInput input)
        {
            return await _service.Add(input);
        }
    }
}