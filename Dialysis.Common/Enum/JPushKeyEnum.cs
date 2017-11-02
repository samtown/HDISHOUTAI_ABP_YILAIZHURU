using System.ComponentModel.DataAnnotations;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// JPushKey枚举
    /// </summary>
    public enum JPushKeyEnum
    {
        /// <summary>
        /// 患教课程
        /// </summary>
        [Display(Description = "患教课程")]
        PatientEducation = 0,

        /// <summary>
        /// 产生体重预警
        /// </summary>
        [Display(Description = "产生体重预警")]
        GenerateAlarm = 1,

        /// <summary>
        /// 确认体重预警
        /// </summary>
        [Display(Description = "确认体重预警")]
        ConfirmAlarm = 2,

        /// <summary>
        /// 透析上机
        /// </summary>
        [Display(Description = "透析上机")]
        DialysisOn = 3,

        /// <summary>
        /// 透析下机
        /// </summary>
        [Display(Description = "透析下机")]
        DialysisOff = 4,
    }
}
