using AutoMapper;
using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Domain;
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
    public class DialysisService
    {
        public readonly DialysisRepository _repository;
        public readonly ShiftRepository _shiftRepository;
        public readonly PatientRepository _patientRepository;
        public readonly MessageRepository _messageRepository;
        public readonly IUnitWork _unitWork;
        private readonly MyOptions _optionsAccessor;

        public DialysisService(DialysisRepository repository, ShiftRepository shiftRepository, PatientRepository patientRepository,
            MessageRepository messageRepository, IUnitWork unitWork, IOptions<MyOptions> optionsAccessor)
        {
            _repository = repository;
            _shiftRepository = shiftRepository;
            _patientRepository = patientRepository;
            _messageRepository = messageRepository;
            _unitWork = unitWork;
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 同步透析上机(新增或修改)
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        public async Task<OutputBase> AddDialysisOn(AddDialysisOnSync sync)
        {
            var patient = await _patientRepository.Get(sync.DialysisPatientId, sync.HospitalId);
            if (patient == null)
            {
                return OutputBase.Fail("患者不存在");
            }

            var shift = await _shiftRepository.Get(sync.DialysisShiftId, sync.HospitalId);
            if (shift == null)
            {
                return OutputBase.Fail("排班信息不存在");
            }

            var dialysis = await _repository.Get(sync.DialysisRecordId, sync.HospitalId);
            if (dialysis == null)
            {
                dialysis = Mapper.Map<AddDialysisOnSync, Domain.Models.Dialysis>(sync);
                dialysis.PatientId = patient.Id;
                dialysis.ShiftId = shift.Id;
                _repository.Add(dialysis);
            }
            else
            {
                dialysis.BedNo = sync.BedNo;
                dialysis.ConfirmedUFV = sync.ConfirmedUFV;
                dialysis.DialysisDate = sync.DialysisDate;
                dialysis.DialysisDuration = sync.DialysisDuration;
                dialysis.PatientId = patient.Id;
                dialysis.ShiftId = shift.Id;
                dialysis.DialysisWay = sync.DialysisWay;
                dialysis.Doctor = sync.Doctor;
                dialysis.DryWeight = sync.DryWeight;
                dialysis.OnBreath = sync.OnBreath;
                dialysis.OnDiastolicPressure = sync.OnDiastolicPressure;
                dialysis.OnNurse = sync.OnNurse;
                dialysis.OnPulseRate = sync.OnPulseRate;
                dialysis.OnSystolicPressure = sync.OnSystolicPressure;
                dialysis.PatientName = sync.PatientName;
                dialysis.PlannedUFV = sync.PlannedUFV;
                dialysis.PreWeight = sync.PreWeight;
                dialysis.StartTime = sync.StartTime;
                dialysis.TreatmentComment = sync.TreatmentComment;
            }

            #region 添加上机Message
            var startTime = sync.StartTime.GetValueOrDefault();
            var content = string.Format("上机时间：{0} 预计下机时间：{1}", startTime.ToString(CommConstant.TimeFormatString),
                    startTime.AddMinutes(sync.DialysisDuration.GetValueOrDefault()).ToString(CommConstant.TimeFormatString));
            var message = new Domain.Models.Message
            {
                AppType = (int)AppTypeEnum.Patient,
                Content = content,
                IsRead = false,
                ReceiveId = patient.Id,
                SendId = 0,
                SendName = "系统",
                Title = "透析前上机测量",
                Type = (int)MessageTypeEnum.透析上机,
                OuterId = dialysis.Id.ToString()
            };
            _messageRepository.Add(message);
            #endregion

            if (!_unitWork.Commit())
            {
                OutputBase.Fail("保存失败");
            }

            #region 向患者端异步发送上机JPush
            ThreadPool.QueueUserWorkItem(delegate
            {
                new JPushMessage(AppTypeEnum.Patient, (int)JPushKeyEnum.DialysisOn, patient.Id.ToString(), content, dialysis.Id.ToString(), _optionsAccessor.IsDevModel).SendPush();
                new JPushNotification(AppTypeEnum.Patient, (int)JPushKeyEnum.DialysisOn, patient.Id.ToString(), content, dialysis.Id.ToString(), _optionsAccessor.IsDevModel).SendPush();
            });
            #endregion

            return OutputBase.Success("保存成功");
        }

        /// <summary>
        /// 同步透析下机
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        public async Task<OutputBase> AddDialysisOff(AddDialysisOffSync sync)
        {
            var dialysis = await _repository.Get(sync.DialysisRecordId, sync.HospitalId);
            if (dialysis == null)
            {
                return OutputBase.Fail("不存在透析上机记录");
            }

            dialysis.ConfirmedUFV = sync.ConfirmedUFV;
            dialysis.StartTime = sync.StartTime;
            dialysis.OffSystolicPressure = sync.OffSystolicPressure;
            dialysis.OffDiastolicPressure = sync.OffDiastolicPressure;
            dialysis.OffPulseRate = sync.OffPulseRate;
            dialysis.OffBreath = sync.OffBreath;
            dialysis.PostWeight = sync.PostWeight;
            dialysis.ActualUFV = sync.ActualUFV;
            dialysis.EndTime = sync.EndTime;
            dialysis.OffNurse = sync.OffNurse;
            dialysis.Summary = sync.Summary;

            #region 添加下机Message
            var endTime = sync.EndTime.GetValueOrDefault();
            var content = string.Format("下机时间： {0}", endTime.ToString(CommConstant.TimeFormatString));
            var message = new Domain.Models.Message
            {
                AppType = (int)AppTypeEnum.Patient,
                Content = content,
                IsRead = false,
                ReceiveId = dialysis.PatientId,
                SendId = 0,
                SendName = "系统",
                Title = "透析前下机测量",
                Type = (int)MessageTypeEnum.透析下机,
                OuterId = dialysis.Id.ToString()
            };
            _messageRepository.Add(message);
            #endregion

            if (!_unitWork.Commit())
            {
                OutputBase.Fail("保存失败");
            }

            #region 向患者端异步发送下机JPush
            ThreadPool.QueueUserWorkItem(delegate
            {
                new JPushMessage(AppTypeEnum.Patient, (int)JPushKeyEnum.DialysisOff, dialysis.PatientId.ToString(), content, dialysis.Id.ToString(), _optionsAccessor.IsDevModel).SendPush();
                new JPushNotification(AppTypeEnum.Patient, (int)JPushKeyEnum.DialysisOff, dialysis.PatientId.ToString(), content, dialysis.Id.ToString(), _optionsAccessor.IsDevModel).SendPush();
            });
            #endregion

            return OutputBase.Success("保存成功");
        }

        /// <summary>
        /// 同步透析小结
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        public async Task<OutputBase> AddDialysisSummary(AddDialysisSummarySync sync)
        {
            var dialysis = await _repository.Get(sync.DialysisRecordId, sync.HospitalId);
            if (dialysis == null)
            {
                return OutputBase.Fail("不存在透析记录");
            }

            dialysis.Summary = sync.Summary;
            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 上机详情
        /// </summary>
        /// <param name="id">透析id</param>
        /// <returns>上机详情</returns>
        public async Task<WebApiOutput<DialysisOnOutput>> GetDialysisOn(long id)
        {
            var dialysis = await _repository.Get(id);
            if (dialysis == null)
            {
                return WebApiOutput<DialysisOnOutput>.Fail("不存在此透析记录");
            }

            return WebApiOutput<DialysisOnOutput>.Success(Mapper.Map<Domain.Models.Dialysis, DialysisOnOutput>(dialysis));
        }

        /// <summary>
        /// 下机详情
        /// </summary>
        /// <param name="id">透析id</param>
        /// <returns>下机详情</returns>
        public async Task<WebApiOutput<DialysisOffOutput>> GetDialysisOff(long id)
        {
            var dialysis = await _repository.Get(id);
            if (dialysis == null)
            {
                return WebApiOutput<DialysisOffOutput>.Fail("不存在此透析记录");
            }

            return WebApiOutput<DialysisOffOutput>.Success(Mapper.Map<Domain.Models.Dialysis, DialysisOffOutput>(dialysis));
        }

        /// <summary>
        /// 获取透析列表
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="refreshMode">0-上拉刷新（获取历史数据），1-下拉刷新（获取最新数据）</param>
        /// <param name="id">透析id（可选参数，第一次不用传）</param>
        /// <returns></returns>
        public async Task<WebApiOutput<List<DialysisListOutput>>> GetDialysisList(long patientId, int pageSize, int refreshMode, long? id)
        {
            var dialysisList = await _repository.GetDialysisList(patientId, pageSize, refreshMode, id);
            return WebApiOutput<List<DialysisListOutput>>.Success(Mapper.Map<List<Domain.Models.Dialysis>, List<DialysisListOutput>>(dialysisList));
        }

        /// <summary>
        /// 透析详情
        /// </summary>
        /// <param name="id">透析id</param>
        /// <returns>透析详情</returns>
        public async Task<WebApiOutput<DialysisDetailOutput>> GetDialysisDetail(long id)
        {
            var dialysis = await _repository.Get(id);
            if (dialysis == null)
            {
                return WebApiOutput<DialysisDetailOutput>.Fail("不存在此透析记录");
            }

            return WebApiOutput<DialysisDetailOutput>.Success(Mapper.Map<Domain.Models.Dialysis, DialysisDetailOutput>(dialysis));
        }

        /// <summary>
        /// 根据透析搜索输入分页获取透析记录
        /// </summary>
        /// <param name="input">透析搜索输入</param>
        /// <returns>透析记录列表</returns>
        public async Task<Tuple<List<AdminDialysisDto>, int>> GetDialysisPageList(DialysisSearchInput input)
        {
            var result = await _repository.GetDialysisPageList(input);

            var tuple = new Tuple<List<AdminDialysisDto>, int>(Mapper.Map<List<Domain.Models.Dialysis>, List<AdminDialysisDto>>(result.Item1), result.Item2);

            return tuple;
        }
    }
}
