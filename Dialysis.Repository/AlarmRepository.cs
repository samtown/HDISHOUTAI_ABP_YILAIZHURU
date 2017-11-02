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
    /// <summary>
    /// 报警
    /// </summary>
    public class AlarmRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public AlarmRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增报警
        /// </summary>
        /// <param name="entity">报警实体</param>
        public void Add(Alarm entity)
        {
            entity.Id = _idGenerator.CreateId();
            entity.AddTime = DateTime.Now;

            _context.Alarm.Add(entity);
        }

        /// <summary>
        /// 确认报警记录
        /// </summary>
        /// <param name="id">报警记录Id</param>
        /// <returns></returns>
        public async Task ConfirmAlarm(long id)
        {
            var alarm = await _context.Alarm.FindAsync(id);
            alarm.IsConfirmed = true;
            alarm.ConfirmedTime = DateTime.Now;
        }

        /// <summary>
        /// 根据报警记录Id获取报警记录详情
        /// </summary>
        /// <param name="id">报警记录Id</param>
        /// <returns>报警记录实体</returns>
        public async Task<Alarm> GetAlarmById(long id)
        {
            var alarm = await _context.Alarm.FindAsync(id);

            return alarm;
        }

        /// <summary>
        /// 获取未确认报警记录数量
        /// </summary>
        /// <param name="input">未确认报警记录数量输入</param>
        /// <returns>未确认报警记录数量</returns>
        public async Task<int> GetNoConfirmedAlarmCount(NoConfirmedAlarmCountInput input)
        {
            var count = await _context.Alarm.Include(i => i.Patient).Where(i => (input.UserType == (int)UserTypeEnum.Nurse ? i.Patient.DoctorId == input.DoctorId : true) && !i.IsConfirmed && i.Patient.HospitalId == input.HospitalId && Math.Abs(i.WeightOverflow / i.PostDialysisWeight) >= 0.03m).CountAsync();

            return count;
        }

        /// <summary>
        /// 根据已确认报警记录输入分页获取已确认报警记录实体列表
        /// </summary>
        /// <param name="input">已确认报警记录输入</param>
        /// <returns>报警记录实体列表</returns>
        public async Task<List<Alarm>> GetConfirmedAlarmList(ConfirmedAlarmListInput input)
        {
            var today = DateTime.Today;
            var toDate = today.AddDays(1);
            var fromDate = input.TimeRangType == (int)TimeRangTypeEnum.OneWeek ? today.AddDays(-7) : (input.TimeRangType == (int)TimeRangTypeEnum.OneMonth ? today.AddMonths(-1) : (input.TimeRangType == (int)TimeRangTypeEnum.ThreeMonths ? today.AddMonths(-3) : today));

            var query = _context.Alarm.Include(i => i.Patient.Doctor).Where(i => (input.DoctorId != 0 /*0代表全部护士*/ ? i.Patient.DoctorId == input.DoctorId : true) && i.AddTime >= fromDate && i.AddTime < toDate && i.IsConfirmed && i.Patient.HospitalId == input.HospitalId && Math.Abs(i.WeightOverflow / i.PostDialysisWeight) >= 0.03m);

            if (input.StartId.HasValue)
            {
                var alarm = await _context.Alarm.FindAsync(input.StartId.Value);
                switch (input.RefreshMode)
                {
                    case (int)RefreshModeEnum.History:
                        query = query.Where(t => t.AddTime < alarm.AddTime).OrderByDescending(i => i.AddTime).Take(input.PageSize);
                        break;
                    case (int)RefreshModeEnum.New:
                        query = query.Where(t => t.AddTime > alarm.AddTime).OrderBy(i => i.AddTime).Take(input.PageSize).OrderByDescending(i => i.AddTime);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(t => t.AddTime).Take(input.PageSize);
            }

            var alarmList = await query.ToListAsync();

            return alarmList;
        }

        /// <summary>
        /// 根据未确认报警记录输入分页获取未确认报警记录实体列表
        /// </summary>
        /// <param name="input">未确认报警记录输入</param>
        /// <returns>报警记录实体列表</returns>
        public async Task<List<Alarm>> GetNoConfirmedAlarmList(NoConfirmedAlarmListInput input)
        {
            var query = _context.Alarm.Include(i => i.Patient.Doctor).Where(i => (input.UserType == (int)UserTypeEnum.Nurse ? i.Patient.DoctorId == input.DoctorId : true) && !i.IsConfirmed && i.Patient.HospitalId == input.HospitalId && Math.Abs(i.WeightOverflow / i.PostDialysisWeight) >= 0.03m);

            if (input.StartId.HasValue)
            {
                var alarm = await _context.Alarm.FindAsync(input.StartId.Value);
                switch (input.RefreshMode)
                {
                    case (int)RefreshModeEnum.History:
                        query = query.Where(t => t.AddTime < alarm.AddTime).OrderByDescending(i => i.AddTime).Take(input.PageSize);
                        break;
                    case (int)RefreshModeEnum.New:
                        query = query.Where(t => t.AddTime > alarm.AddTime).OrderBy(i => i.AddTime).Take(input.PageSize).OrderByDescending(i => i.AddTime);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(t => t.AddTime).Take(input.PageSize);
            }

            var alarmList = await query.ToListAsync();

            return alarmList;
        }
    }
}
