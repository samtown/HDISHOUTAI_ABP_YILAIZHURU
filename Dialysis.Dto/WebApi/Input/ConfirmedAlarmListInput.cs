using Dialysis.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 已确认报警记录输入
    /// </summary>
    public class ConfirmedAlarmListInput : AppRefreshBase
    {
        /// <summary>
        /// 时间段类型（0：1星期，1：1个月，2:3个月）
        /// </summary>
        public int TimeRangType { get; set; }

        /// <summary>
        /// 医护人员Id（为0时表示全部护士）
        /// </summary>
        public long DoctorId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }
    }
}
