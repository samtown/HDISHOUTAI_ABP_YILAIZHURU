using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 患者血糖
    /// </summary>
    public class BloodSugar
    {
        /// <summary>
        /// 体重Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 血糖值
        /// </summary>
        public decimal Value { get; set; }

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
