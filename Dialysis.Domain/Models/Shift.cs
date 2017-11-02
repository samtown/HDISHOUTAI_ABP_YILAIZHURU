using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 班次表
    /// </summary>
    public class Shift
    {
        /// <summary>
        /// 班次主键
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 透析班次Id（华墨系统Id）
        /// </summary>
        public int DialysisShiftId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// 班次名称
        /// </summary>
        [Required]
        [StringLength(8)]
        public string ShiftName { get; set; }

        /// <summary>
        /// 班次类别
        /// </summary>
        [Required]
        [StringLength(8)]
        public string ShiftType { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [StringLength(8)]
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [StringLength(8)]
        public string EndTime { get; set; }

        /// <summary>
        /// 患者所属医院
        /// </summary>
        public virtual Hospital Hospital { get; set; }

        /// <summary>
        /// 透析记录
        /// </summary>
        public virtual ICollection<Dialysis> Dialysiss { get; set; }
    }
}
