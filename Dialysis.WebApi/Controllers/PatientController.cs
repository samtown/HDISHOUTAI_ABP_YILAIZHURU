using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 患者
    /// </summary>
    [Produces("application/json")]
    [Route("api/Patient")]
    public class PatientController : Controller
    {
        private readonly PatientService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public PatientController(PatientService service)
        {
            _service = service;
        }

        /// <summary>
        /// 患者登陆
        /// </summary>
        /// <param name="input">登录输入</param>
        /// <returns>医护人员登录输出</returns>
        [HttpPost("Login")]
        public async Task<WebApiOutput<PatientLoginOutput>> Login([FromBody]CommonLoginInput input)
        {
            return await _service.Login(input);
        }

        ///// <summary>
        ///// 修改密码
        ///// </summary>
        ///// <param name="input">修改患者密码输入</param>
        ///// <returns>是否成功</returns>
        //[HttpPut("UpdatePassword")]
        //public async Task<OutputBase> UpdatePassword([FromBody]UpdatePasswordInput input)
        //{
        //    return await _service.UpdatePassword(input);
        //}

        /// <summary>
        /// 修改医护人员头像
        /// </summary>
        /// <param name="input">修改患者头像输入</param>
        /// <returns>是否成功</returns>
        [HttpPut("UpdateFace")]
        public async Task<WebApiOutput<string>> UpdateFace([FromBody]UpdateFaceInput input)
        {
            return await _service.UpdateFace(input);
        }

        /// <summary>
        /// 根据患者列表输入获取患者基本信息列表
        /// </summary>
        /// <param name="input">患者列表输入</param>
        /// <returns>患者基本信息列表</returns>
        [HttpGet("{userType}/{doctorId}/{hospitalId}")]
        public async Task<WebApiOutput<List<PatientBaseDto>>> GetPatientListByDoctor(PatientListInput input)
        {
            return await _service.GetPatientListByDoctor(input);
        }

        /// <summary>
        /// 根据患者Id获取患者详细信息
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>患者详细信息</returns>
        [HttpGet("{patientId}")]
        public async Task<WebApiOutput<PatientDto>> GetPatientById(long patientId)
        {
            return await _service.GetPatientById(patientId);
        }

        /// <summary>
        /// 修改患者干体重
        /// </summary>
        /// <param name="input">修改患者干体重请求</param>
        /// <returns>是否成功</returns>
        [HttpPut("UpdateWeight")]
        public async Task<OutputBase> UpdateWeight([FromBody]UpdateWeightInput input)
        {
            return await _service.UpdateWeight(input);
        }

        /// <summary>
        /// 修改患者身高
        /// </summary>
        /// <param name="input">修改患者身高请求</param>
        /// <returns>是否成功</returns>
        [HttpPut("UpdateHeight")]
        public async Task<OutputBase> UpdateHeight([FromBody]UpdateHeightInput input)
        {
            return await _service.UpdateHeight(input);
        }

        /// <summary>
        /// 修改水杯MAC
        /// </summary>
        /// <param name="input"></param>
        /// <returns>是否成功</returns>
        [HttpPut("UpdateCupMAC")]
        public async Task<OutputBase> UpdateCupMAC([FromBody]UpdateCupMACInput input)
        {
            return await _service.UpdateCupMAC(input);
        }
    }
}