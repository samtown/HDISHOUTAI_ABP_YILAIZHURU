using AutoMapper;
using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class WeightService
    {
        public readonly WeightRepository _repository;
        public readonly AlarmRepository _alarmRepository;
        public readonly PatientRepository _patientRepository;
        public readonly MessageRepository _messageRepository;
        public readonly IUnitWork _unitWork;
        private readonly MyOptions _optionsAccessor;

        public WeightService(WeightRepository repository, AlarmRepository alarmRepository, PatientRepository patientRepository, MessageRepository messageRepository, IUnitWork unitWork, IOptions<MyOptions> optionsAccessor)
        {
            _repository = repository;
            _alarmRepository = alarmRepository;
            _patientRepository = patientRepository;
            _messageRepository = messageRepository;
            _unitWork = unitWork;
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 同步体重
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        public async Task<OutputBase> Add(AddWeightSync sync)
        {
            if (await _repository.IsExist(sync.DialysisWeightId, sync.HospitalId))
            {
                return OutputBase.Fail("此体重数据已存在");
            }

            var patient = await _patientRepository.Get(sync.DialysisPatientId, sync.HospitalId);
            if (patient == null)
            {
                return OutputBase.Fail("此患者不存在");
            }

            var weight = Mapper.Map<AddWeightSync, Weight>(sync);
            #region 兼容华墨数据，华墨数据库中测量方式透后为1，我们平台统一为2
            if (sync.MeasureType == 1)
            {
                weight.MeasureType = (int)MeasureTypeEnum.透后;
            }
            #endregion
            weight.PatientId = patient.Id;
            _repository.Add(weight);
            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 新增体重
        /// </summary>
        /// <param name="input">体重输入</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Add(AddWeightInput input)
        {
            var weight = Mapper.Map<AddWeightInput, Weight>(input);
            var measureTime = DateTime.Now;
            weight.MeasureMethod = (int)MeasureMethodEnum.App;
            weight.MeasureTime = measureTime;
            _repository.Add(weight);

            var latestPostDialysisWeight = await _repository.GetLatestPostDialysisWeight(input.PatientId);
            if (latestPostDialysisWeight == null)
                return _unitWork.Commit() ? OutputBase.Success("新增报警记录成功") : OutputBase.Fail("新增报警记录失败");

            var alarmEntity = new Alarm
            {
                PostDialysisWeight = latestPostDialysisWeight.Value,
                PostDialysisTime = latestPostDialysisWeight.MeasureTime,
                PatientId = input.PatientId,
                CurrentWeight = input.Value,
                CurrentWeightTime = measureTime,
                IsConfirmed = false,
                WeightOverflow = Math.Round(input.Value - latestPostDialysisWeight.Value, 2)
            };
            var percentage = Math.Abs(alarmEntity.WeightOverflow / alarmEntity.PostDialysisWeight);
            if (percentage >= 0.03m)
            {
                _alarmRepository.Add(alarmEntity);
                var patient = await _patientRepository.GetPatientById(input.PatientId);

                string content = string.Format("{0}产生体重预警", patient.PatientName);
                var messageEntity = new Message
                {
                    IsRead = false,
                    Content = content,
                    ReceiveId = patient.DoctorId.HasValue ? patient.DoctorId.Value : 0,
                    Title = "产生体重预警",
                    Type = (int)MessageTypeEnum.产生体重预警,
                    SendId = input.PatientId,
                    SendName = patient.PatientName,
                    Url = string.Empty,
                    AppType = (int)AppTypeEnum.Doctor
                };
                _messageRepository.Add(messageEntity);

                if (!_unitWork.Commit())
                    return OutputBase.Fail("新增报警记录失败");
                #region 异步发送JPush Notification、Message
                ThreadPool.QueueUserWorkItem(delegate
                {
                    string tag;
                    if (patient.DoctorId.HasValue)
                    {
                        tag = patient.DoctorId.Value.ToString();
                    }
                    else
                    {
                        tag = input.HospitalId.ToString();
                    }
                    new JPushMessage(AppTypeEnum.Doctor, (int)JPushKeyEnum.GenerateAlarm, tag, content, messageEntity.OuterId, _optionsAccessor.IsDevModel).SendPush();
                    new JPushNotification(AppTypeEnum.Doctor, (int)JPushKeyEnum.GenerateAlarm, tag, content, messageEntity.OuterId, _optionsAccessor.IsDevModel).SendPush();
                });
                #endregion
                return OutputBase.Success("新增报警记录成功");
            }

            return _unitWork.Commit() ? OutputBase.Success("新增报警记录成功") : OutputBase.Fail("新增报警记录失败");
        }

        /// <summary>
        /// 获取top数量体重记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>体重记录列表</returns>
        public async Task<WebApiOutput<List<WeightDto>>> GetTopWeightList(CommonIndexInput input)
        {
            var weightList = await _repository.GetTopWeightList(input);

            return WebApiOutput<List<WeightDto>>.Success(Mapper.Map<List<Weight>, List<WeightDto>>(weightList));
        }

        /// <summary>
        /// 获取top数量体重记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>体重记录列表</returns>
        public async Task<List<AdminWeightDto>> GetAdminTopWeightList(CommonIndexInput input)
        {
            var weightList = await _repository.GetTopWeightList(input);

            return Mapper.Map<List<Weight>, List<AdminWeightDto>>(weightList);
        }
    }
}
