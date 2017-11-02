using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 消息
    /// </summary>
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        private readonly MessageService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public MessageController(MessageService service)
        {
            _service = service;
        }

        /// <summary>
        /// 更新消息已读
        /// </summary>
        /// <param name="messageId">消息ID</param>
        /// <returns>是否成功</returns>
        [HttpPut("{messageId}")]
        public async Task<OutputBase> UpdateMessageRead(long messageId)
        {
            return await _service.UpdateMessageRead(messageId);
        }

        /// <summary>
        /// 根据患者Id分页获取首页消息列表(患教课程除外)
        /// </summary>
        /// <param name="input">消息搜索输入</param>
        /// <returns>消息列表</returns>
        [HttpGet("HomePage/{patientId}/{refreshMode}/{pageSize}/{startId?}")]
        public async Task<WebApiOutput<List<MessageDto>>> GetMessageListByPatientId(MessageSearchInput input)
        {
            return await _service.GetMessageListByPatientId(input);
        }

        /// <summary>
        /// 根据患者Id分页获取患教课程消息列表
        /// </summary>
        /// <param name="input">消息搜索输入</param>
        /// <returns>患教课程消息列表</returns>
        [HttpGet("PatientEdu/{patientId}/{refreshMode}/{pageSize}/{startId?}")]
        public async Task<WebApiOutput<List<MessageDto>>> GetPatientEduMessageListByPatientId(MessageSearchInput input)
        {
            return await _service.GetPatientEduMessageListByPatientId(input);
        }
    }
}