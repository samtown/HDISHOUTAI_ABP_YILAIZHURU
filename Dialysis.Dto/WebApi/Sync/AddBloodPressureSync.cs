using System;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddBloodPressureSync
    /// </summary>
    public class AddBloodPressureSync
    {
        /// <summary>
        /// 透析血压Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisBloodPressureId { get; set; }

        /// <summary>
        /// 透析患者Id(华墨患者Id)
        /// </summary>
        [Required]
        public int DialysisPatientId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        [Required]
        public long HospitalId { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        [Required]
        public DateTime MeasureTime { get; set; }

        /// <summary>
        /// 测量类型(0-透前；1-透中；2-透后；99-日常)
        /// </summary>
        [Required]
        public int MeasureType { get; set; }

        /// <summary>
        /// 测量方法(0-手工；1-自助；2-血透机；3-监护仪；99-App)
        /// </summary>
        [Required]
        public int MeasureMethod { get; set; }

        /// <summary>
        /// 收缩压(mmHg)
        /// </summary>
        [Required]
        public int SystolicPressure { get; set; }

        /// <summary>
        /// 舒张压(mmHg)
        /// </summary>
        [Required]
        public int DiastolicPressure { get; set; }

        /// <summary>
        /// 平均动脉压(mmHg)
        /// </summary>
        public int? MeanArterialPressure { get; set; }

        /// <summary>
        /// 心率(次/分)
        /// </summary>
        [Required]
        public int PulseRate { get; set; }

        /// <summary>
        /// 呼吸(次/分)
        /// </summary>
        public int? Breath { get; set; }
    }
}
