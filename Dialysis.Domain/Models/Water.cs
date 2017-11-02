using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 患者饮水表
    /// </summary>
    public class Water
    {
        /// <summary>
        /// 饮水量Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 饮水量
        /// </summary>
        public int DrinkVolume { get; set; }

        /// <summary>
        /// 饮水时间
        /// </summary>
        public DateTime DrinkTime { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
