using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 报警
    /// </summary>
    [Produces("application/json")]
    [Route("api/Alarm")]
    public class AlarmController : Controller
    {
        private readonly AlarmService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public AlarmController(AlarmService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取未确认报警记录数量
        /// </summary>
        /// <param name="input">未确认报警数量输入</param>
        /// <returns>数量</returns>
        [HttpGet("NoConfirmedAlarmCount/{userType}/{doctorId}/{hospitalId}")]
        public async Task<WebApiOutput<int>> GetNoConfirmedAlarmCount(NoConfirmedAlarmCountInput input)
        {
            return await _service.GetNoConfirmedAlarmCount(input);
        }

        /// <summary>
        /// 根据报警记录Id获取报警记录详情
        /// </summary>
        /// <param name="alarmId">报警记录Id</param>
        /// <returns>报警记录详情</returns>
        [HttpGet("{alarmId}")]
        public async Task<WebApiOutput<AlarmDto>> GetAlarmById(long alarmId)
        {
            return await _service.GetAlarmById(alarmId);
        }

        /// <summary>
        /// 根据未确认报警记录输入获取未确认报警记录列表
        /// </summary>
        /// <param name="input">未确认报警记录输入</param>
        /// <returns>未确认报警记录列表</returns>
        [HttpGet("NoConfirmed/{userType}/{doctorId}/{hospitalId}/{refreshMode}/{pageSize}/{startId?}")]
        public async Task<WebApiOutput<List<AlarmDto>>> GetNoConfirmedAlarmList(NoConfirmedAlarmListInput input)
        {
            return await _service.GetNoConfirmedAlarmList(input);
        }

        /// <summary>
        /// 根据已确认报警记录输入获取已确认报警记录列表
        /// </summary>
        /// <param name="input">已确认报警记录输入</param>
        /// <returns>已确认报警记录列表</returns>
        [HttpGet("Confirmed/{timeRangType}/{doctorId}/{hospitalId}/{refreshMode}/{pageSize}/{startId?}")]
        public async Task<WebApiOutput<List<AlarmDto>>> GetConfirmedAlarmList(ConfirmedAlarmListInput input)
        {
            return await _service.GetConfirmedAlarmList(input);
        }

        /// <summary>
        /// 确认报警记录
        /// </summary>
        /// <param name="input">确认报警记录输入</param>
        /// <returns>是否成功</returns>
        [HttpPut]
        public async Task<OutputBase> ConfirmAlarm([FromBody]ConfirmAlarmInput input)
        {
            return await _service.ConfirmAlarm(input);
        }
    }
}