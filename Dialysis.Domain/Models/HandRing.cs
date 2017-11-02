using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 手环
    /// </summary>
    public class HandRing
    {
        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        /// <summary>
        /// 步数
        /// </summary>
        public int Steps { get; set; }

        /// <summary>
        /// 距离(米)
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// 睡眠时间(分钟)
        /// </summary>
        public int SleepTime { get; set; }

        /// <summary>
        /// 能量
        /// </summary>
        public decimal Energy { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
