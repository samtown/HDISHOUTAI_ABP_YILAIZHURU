using System;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddDialysisOnSync
    /// </summary>
    public class AddDialysisOnSync
    {
        /// <summary>
        /// 透析记录Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisRecordId { get; set; }

        /// <summary>
        /// 透析班次Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisShiftId { get; set; }

        /// <summary>
        /// 透析患者ID(华墨系统Id)
        /// </summary>
        [Required]
        public int DialysisPatientId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        [Required]
        public long HospitalId { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Required]
        [StringLength(32)]
        public string PatientName { get; set; }

        /// <summary>
        /// 透析日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DialysisDate { get; set; }

        /// <summary>
        /// 透析时长(min)
        /// </summary>
        public int? DialysisDuration { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        [StringLength(8)]
        public string BedNo { get; set; }

        /// <summary>
        /// 透析方式
        /// </summary>
        [StringLength(16)]
        public string DialysisWay { get; set; }

        #region 上机
        /// <summary>
        /// 上机收缩压(mmHg)
        /// </summary>
        public int? OnSystolicPressure { get; set; }

        /// <summary>
        /// 上机舒张压(mmHg)
        /// </summary>
        public int? OnDiastolicPressure { get; set; }

        /// <summary>
        /// 上机心率(次/分)
        /// </summary>
        public int? OnPulseRate { get; set; }

        /// <summary>
        /// 上机呼吸(次/分)
        /// </summary>
        public int? OnBreath { get; set; }

        /// <summary>
        /// 干体重(kg)
        /// </summary>
        public decimal? DryWeight { get; set; }

        /// <summary>
        /// 透前体重(kg)
        /// </summary>
        public decimal? PreWeight { get; set; }

        /// <summary>
        /// 预脱
        /// </summary>
        public decimal? PlannedUFV { get; set; }

        /// <summary>
        /// 定容
        /// </summary>
        public decimal? ConfirmedUFV { get; set; }

        /// <summary>
        /// 开始时间/上机时间
        /// </summary>
        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 上机护士
        /// </summary>
        [StringLength(16)]
        public string OnNurse { get; set; }

        /// <summary>
        /// 责任医生
        /// </summary>
        [StringLength(16)]
        public string Doctor { get; set; }

        /// <summary>
        /// 病情与处理
        /// </summary>
        [StringLength(512)]
        public string TreatmentComment { get; set; }
        #endregion
    }
}
