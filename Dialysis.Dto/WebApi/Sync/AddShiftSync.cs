using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddShiftSync
    /// </summary>
    public class AddShiftSync
    {
        /// <summary>
        /// 透析班次Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisShiftId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        [Required]
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
    }
}
