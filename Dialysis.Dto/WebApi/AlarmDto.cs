using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 报警
    /// </summary>
    public class AlarmDto
    {
        /// <summary>
        /// 报警记录Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 透后体重
        /// </summary>
        public decimal PostDialysisWeight { get; set; }

        /// <summary>
        /// 透后时间
        /// </summary>
        public DateTime PostDialysisTime { get; set; }

        /// <summary>
        /// 本次称重
        /// </summary>
        public decimal CurrentWeight { get; set; }

        /// <summary>
        /// 称重日期
        /// </summary>
        public DateTime CurrentWeightTime { get; set; }

        /// <summary>
        /// 体重超值
        /// </summary>
        public decimal WeightOverflow { get; set; }

        /// <summary>
        /// 所属医生姓名
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 患者头像
        /// </summary>
        public string PatientFace { get; set; }

        /// <summary>
        /// 颜色类型（0：蓝色，1：黄色，2：红色）
        /// </summary>
        public int ColourType { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime? ConfirmedTime { get; set; }
    }
}
