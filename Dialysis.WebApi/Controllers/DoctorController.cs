using Dialysis.Common.Enum;
using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 医护人员
    /// </summary>
    [Produces("application/json")]
    [Route("api/Doctor")]
    public class DoctorController : Controller
    {
        private readonly DoctorService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public DoctorController(DoctorService service)
        {
            _service = service;
        }

        /// <summary>
        /// 医护人员登录
        /// </summary>
        /// <param name="input">登录输入</param>
        /// <returns>医护人员登录输出</returns>
        [HttpPost("Login")]
        public async Task<WebApiOutput<DoctorLoginOutput>> Login([FromBody]CommonLoginInput input)
        {
            return await _service.Login(input);
        }

        /// <summary>
        /// 根据医院Id获取护士列表
        /// </summary>
        /// <param name="hospitalId">医院Id</param>
        /// <returns>护士列表</returns>
        [HttpGet("NurseList/{hospitalId}")]
        public async Task<WebApiOutput<List<DictDto>>> GetNurseList(long hospitalId)
        {
            //2代表护士
            return await _service.GetDoctorList((int)UserTypeEnum.Nurse, hospitalId);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="input">修改医护人员密码输入</param>
        /// <returns>是否成功</returns>
        [HttpPut("UpdatePassword")]
        public async Task<OutputBase> UpdatePassword([FromBody]UpdatePasswordInput input)
        {
            return await _service.UpdatePassword(input);
        }

        /// <summary>
        /// 修改医护人员头像
        /// </summary>
        /// <param name="input">修改医护人员头像输入</param>
        /// <returns>是否成功</returns>
        [HttpPut("UpdateFace")]
        public async Task<WebApiOutput<string>> UpdateFace([FromBody]UpdateFaceInput input)
        {
            return await _service.UpdateFace(input);
        }
    }
}