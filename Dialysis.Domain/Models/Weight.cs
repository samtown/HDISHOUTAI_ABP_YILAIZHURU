using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 体重
    /// </summary>
    public class Weight
    {
        /// <summary>
        /// 体重Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 透析体重Id（华墨系统Id）
        /// </summary>
        public int? DialysisWeightId { get; set; }

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
        /// 测量类型(0-透前；2-透后；99-日常)
        /// </summary>
        public int MeasureType { get; set; }

        /// <summary>
        /// 测量方法(0-手工；1-自助；99-App)
        /// </summary>
        public int MeasureMethod { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
