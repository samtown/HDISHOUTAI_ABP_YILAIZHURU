using System;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddDialysisOffSync
    /// </summary>
    public class AddDialysisOffSync
    {
        /// <summary>
        /// 透析记录Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisRecordId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        [Required]
        public long HospitalId { get; set; }

        /// <summary>
        /// 开始时间/上机时间
        /// </summary>
        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 定容
        /// </summary>
        public decimal? ConfirmedUFV { get; set; }

        #region 下机
        /// <summary>
        /// 下机收缩压(mmHg)
        /// </summary>
        public int? OffSystolicPressure { get; set; }

        /// <summary>
        /// 下机舒张压(mmHg)
        /// </summary>
        public int? OffDiastolicPressure { get; set; }

        /// <summary>
        /// 下机心率(次/分)
        /// </summary>
        public int? OffPulseRate { get; set; }

        /// <summary>
        /// 下机呼吸(次/分)
        /// </summary>
        public int? OffBreath { get; set; }

        /// <summary>
        /// 透后体重(kg)
        /// </summary>
        public decimal? PostWeight { get; set; }

        /// <summary>
        /// 实脱
        /// </summary>
        public decimal? ActualUFV { get; set; }

        /// <summary>
        /// 结束时间/下机时间
        /// </summary>
        [DataType(DataType.Time)]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 下机护士
        /// </summary>
        [StringLength(16)]
        public string OffNurse { get; set; }
        #endregion

        #region 总结
        /// <summary>
        /// 透析小结
        /// </summary>
        [StringLength(512)]
        public string Summary { get; set; }
        #endregion
    }
}
