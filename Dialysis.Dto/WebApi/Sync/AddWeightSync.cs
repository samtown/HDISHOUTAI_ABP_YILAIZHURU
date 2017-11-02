using System;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddWeightSync
    /// </summary>
    public class AddWeightSync
    {
        /// <summary>
        /// 透析体重Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisWeightId { get; set; }

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
        /// 测量类型(0-透前；1-透后；)
        /// </summary>
        [Required]
        public int MeasureType { get; set; }

        /// <summary>
        /// 测量方法(0-手工；1-自助；)
        /// </summary>
        [Required]
        public int MeasureMethod { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [Required]
        public decimal Value { get; set; }
    }
}
