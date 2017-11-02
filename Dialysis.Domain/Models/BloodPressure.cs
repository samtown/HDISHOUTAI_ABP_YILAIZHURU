using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 血压
    /// </summary>
    public class BloodPressure
    {
        /// <summary>
        /// 血压Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 透析血压Id（华墨系统Id）
        /// </summary>
        public int? DialysisBloodPressureId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime MeasureTime { get; set; }

        /// <summary>
        /// 测量类型(0-透前；1-透中；2-透后；99-日常)
        /// </summary>
        public int MeasureType { get; set; }

        /// <summary>
        /// 测量方法(0-手工；1-自助；2-血透机；3-监护仪；99-App)
        /// </summary>
        public int MeasureMethod { get; set; }

        /// <summary>
        /// 收缩压(mmHg)
        /// </summary>
        public int SystolicPressure { get; set; }

        /// <summary>
        /// 舒张压(mmHg)
        /// </summary>
        public int DiastolicPressure { get; set; }

        /// <summary>
        /// 平均动脉压(mmHg)
        /// </summary>
        public int? MeanArterialPressure { get; set; }

        /// <summary>
        /// 心率(次/分)
        /// </summary>
        public int PulseRate { get; set; }

        /// <summary>
        /// 呼吸(次/分)
        /// </summary>
        public int? Breath { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
