using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class MessageService
    {
        public readonly MessageRepository _repository;
        public readonly IUnitWork _unitWork;

        public MessageService(MessageRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 更新消息已读
        /// </summary>
        /// <param name="messageId">消息Id</param>
        /// <returns>是否更新成功</returns>
        public async Task<OutputBase> UpdateMessageRead(long messageId)
        {
            await _repository.UpdateMessageRead(messageId);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 根据患者Id和指定页码获取首页消息列表(患教课程除外)
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="pageIndex">指定页码</param>
        /// <returns>消息列表(患教课程除外)</returns>
        public async Task<WebApiOutput<List<MessageDto>>> GetMessageListByPatientId(MessageSearchInput input)
        {
            var messageList = await _repository.GetMessageListByPatientId(input);

            return WebApiOutput<List<MessageDto>>.Success(Mapper.Map<List<Message>, List<MessageDto>>(messageList));
        }

        /// <summary>
        /// 根据患者Id和指定页码获取患教课程消息列表
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="pageIndex">指定页码</param>
        /// <returns>患教课程消息列表</returns>
        public async Task<WebApiOutput<List<MessageDto>>> GetPatientEduMessageListByPatientId(MessageSearchInput input)
        {
            var messageList = await _repository.GetPatientEduMessageListByPatientId(input);

            return WebApiOutput<List<MessageDto>>.Success(Mapper.Map<List<Message>, List<MessageDto>>(messageList));
        }
    }
}
