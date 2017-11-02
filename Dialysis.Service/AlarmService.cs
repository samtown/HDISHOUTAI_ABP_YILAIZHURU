using AutoMapper;
using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class AlarmService
    {
        public readonly AlarmRepository _repository;
        public readonly DoctorRepository _doctorRepository;
        public readonly MessageRepository _messageRepository;
        public readonly IUnitWork _unitWork;
        private readonly MyOptions _optionsAccessor;

        public AlarmService(AlarmRepository repository, DoctorRepository doctorRepository, MessageRepository messageRepository, IUnitWork unitWork, IOptions<MyOptions> optionsAccessor)
        {
            _repository = repository;
            _unitWork = unitWork;
            _doctorRepository = doctorRepository;
            _messageRepository = messageRepository;
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 获取未确认报警记录数量
        /// </summary>
        /// <param name="input">未确认报警数量输入</param>
        /// <returns>数量</returns>
        public async Task<WebApiOutput<int>> GetNoConfirmedAlarmCount(NoConfirmedAlarmCountInput input)
        {
            var count = await _repository.GetNoConfirmedAlarmCount(input);

            return WebApiOutput<int>.Success(count);
        }

        /// <summary>
        /// 根据报警记录Id获取报警记录详情
        /// </summary>
        /// <param name="alarmId">报警记录Id</param>
        /// <returns>报警记录详情</returns>
        public async Task<WebApiOutput<AlarmDto>> GetAlarmById(long alarmId)
        {
            var alarm = await _repository.GetAlarmById(alarmId);

            return WebApiOutput<AlarmDto>.Success(Mapper.Map<Alarm, AlarmDto>(alarm));
        }

        /// <summary>
        /// 根据未确认报警记录输入获取未确认报警记录列表
        /// </summary>
        /// <param name="input">未确认报警记录输入</param>
        /// <returns>未确认报警记录列表</returns>
        public async Task<WebApiOutput<List<AlarmDto>>> GetNoConfirmedAlarmList(NoConfirmedAlarmListInput input)
        {
            var alarmList = await _repository.GetNoConfirmedAlarmList(input);

            return WebApiOutput<List<AlarmDto>>.Success(Mapper.Map<List<Alarm>, List<AlarmDto>>(alarmList));
        }

        /// <summary>
        /// 根据已确认报警记录输入获取已确认报警记录列表
        /// </summary>
        /// <param name="input">已确认报警记录输入</param>
        /// <returns>已确认报警记录列表</returns>
        public async Task<WebApiOutput<List<AlarmDto>>> GetConfirmedAlarmList(ConfirmedAlarmListInput input)
        {
            var alarmList = await _repository.GetConfirmedAlarmList(input);

            return WebApiOutput<List<AlarmDto>>.Success(Mapper.Map<List<Alarm>, List<AlarmDto>>(alarmList));
        }

        /// <summary>
        /// 确认报警记录
        /// </summary>
        /// <param name="input">确认报警记录输入</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> ConfirmAlarm(ConfirmAlarmInput input)
        {

            var alarm = await _repository.GetAlarmById(input.AlarmId);
            if (alarm == null)
                return OutputBase.Fail("该报警记录不存在");
            var doctor = await _doctorRepository.GetDoctorById(input.DoctorId);
            if (doctor == null)
                return OutputBase.Fail("确认的医护人员不存在");
            await _repository.ConfirmAlarm(input.AlarmId);
            string content = string.Format("{0}医生确认了您的体重预警", doctor.Name);
            var entity = new Message
            {
                IsRead = false,
                Content = content,
                ReceiveId = alarm.PatientId,
                Title = "确认体重预警",
                Type = (int)MessageTypeEnum.确认体重预警,
                SendId = input.DoctorId,
                SendName = doctor.Name,
                Url = string.Empty,
                OuterId = input.AlarmId.ToString(),
                AppType = (int)AppTypeEnum.Patient
            };
            _messageRepository.Add(entity);
            if (!_unitWork.Commit())
                return OutputBase.Fail("确认失败");
            #region 异步发送JPush Notification、Message
            ThreadPool.QueueUserWorkItem(delegate
            {

                new JPushMessage(AppTypeEnum.Patient, (int)JPushKeyEnum.ConfirmAlarm, alarm.PatientId.ToString(), content, entity.OuterId, _optionsAccessor.IsDevModel).SendPush();
                new JPushNotification(AppTypeEnum.Patient, (int)JPushKeyEnum.ConfirmAlarm, alarm.PatientId.ToString(), content, entity.OuterId, _optionsAccessor.IsDevModel).SendPush();
            });
            #endregion

            return OutputBase.Success("确认成功");
        }
    }
}
