using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class MessageRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public MessageRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增消息
        /// </summary>
        /// <param name="entity">消息实体</param>
        public void Add(Message entity)
        {
            entity.Id = _idGenerator.CreateId();
            entity.SendTime = DateTime.Now;

            _context.Message.Add(entity);
        }

        /// <summary>
        /// 更新消息已读
        /// </summary>
        /// <param name="id">消息Id</param>
        public async Task UpdateMessageRead(long id)
        {
            var message = await _context.Message.FindAsync(id);
            message.IsRead = true;
        }

        /// <summary>
        /// 根据消息Id获取消息实体
        /// </summary>
        /// <param name="id">消息Id</param>
        /// <returns>消息实体</returns>
        public async Task<Message> GetMessageById(long id)
        {
            var message = await _context.Message.FindAsync(id);

            return message;
        }

        /// <summary>
        /// 根据患者Id和指定页码获取消息实体列表(患教课程除外)
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="pageIndex">指定页码</param>
        /// <returns>消息实体列表(患教课程除外)</returns>
        public async Task<List<Message>> GetMessageListByPatientId(MessageSearchInput input)
        {
            var query = _context.Message.Where(i => i.ReceiveId == input.PatientId && i.AppType == (int)AppTypeEnum.Patient && i.Type != (int)MessageTypeEnum.患教课程);
            if (input.StartId.HasValue)
            {
                var message = await _context.Message.FindAsync(input.StartId.Value);
                switch (input.RefreshMode)
                {
                    case (int)RefreshModeEnum.History:
                        query = query.Where(t => t.SendTime < message.SendTime).OrderByDescending(i => i.SendTime).Take(input.PageSize);
                        break;
                    case (int)RefreshModeEnum.New:
                        query = query.Where(t => t.SendTime > message.SendTime).OrderBy(i => i.SendTime).Take(input.PageSize).OrderByDescending(i => i.SendTime);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(t => t.SendTime).Take(input.PageSize);
            }

            var messageList = await query.ToListAsync();

            return messageList;
        }

        /// <summary>
        /// 根据患者Id和指定页码获取患教课程消息实体列表
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="pageIndex">指定页码</param>
        /// <returns>患教课程消息实体列表</returns>
        public async Task<List<Message>> GetPatientEduMessageListByPatientId(MessageSearchInput input)
        {
            var query = _context.Message.Where(i => i.ReceiveId == input.PatientId && i.AppType == (int)AppTypeEnum.Patient && i.Type == (int)MessageTypeEnum.患教课程);
            if (input.StartId.HasValue)
            {
                var message = await _context.Message.FindAsync(input.StartId.Value);
                switch (input.RefreshMode)
                {
                    case (int)RefreshModeEnum.History:
                        query = query.Where(t => t.SendTime < message.SendTime).OrderByDescending(i => i.SendTime).Take(input.PageSize);
                        break;
                    case (int)RefreshModeEnum.New:
                        query = query.Where(t => t.SendTime > message.SendTime).OrderBy(i => i.SendTime).Take(input.PageSize).OrderByDescending(i => i.SendTime);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(t => t.SendTime).Take(input.PageSize);
            }

            var messageList = await query.ToListAsync();

            return messageList;
        }
    }
}
