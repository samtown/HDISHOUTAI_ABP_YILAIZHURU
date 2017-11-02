using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 报警
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// 报警Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        [DataType(DataType.DateTime)]
        public DateTime PostDialysisTime { get; set; }

        /// <summary>
        /// 本次称重
        /// </summary>
        public decimal CurrentWeight { get; set; }

        /// <summary>
        /// 称重时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CurrentWeightTime { get; set; }

        /// <summary>
        /// 体重超值
        /// </summary>
        public decimal WeightOverflow { get; set; }

        /// <summary>
        /// 是否已经确认
        /// </summary>
        public bool IsConfirmed { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime? ConfirmedTime { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
