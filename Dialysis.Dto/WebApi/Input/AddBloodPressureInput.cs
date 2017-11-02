using System;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddBloodPressureInput
    /// </summary>
    public class AddBloodPressureInput
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Required]
        public long PatientId { get; set; }

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
        /// 心率(次/分)
        /// </summary>
        public int PulseRate { get; set; }
    }
}
