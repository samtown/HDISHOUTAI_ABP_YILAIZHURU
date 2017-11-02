using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 确认报警输入
    /// </summary>
    public class ConfirmAlarmInput
    {
        /// <summary>
        /// 报警记录Id
        /// </summary>
        public long AlarmId { get; set; }

        /// <summary>
        /// 医护人员Id
        /// </summary>
        public long DoctorId { get; set; }
    }
}
