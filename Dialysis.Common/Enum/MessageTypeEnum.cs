using System.ComponentModel.DataAnnotations;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// 消息类型枚举
    /// </summary>
    public enum MessageTypeEnum
    {
        /// <summary>
        /// 类型（0：患教课程，1：产生体重预警，2：确认体重预警）
        /// </summary>
        [Display(Description = "患教课程")]
        患教课程 = 0,

        /// <summary>
        /// 产生体重预警
        /// </summary>
        [Display(Description = "产生体重预警")]
        产生体重预警 = 1,

        /// <summary>
        /// 确认体重预警
        /// </summary>
        [Display(Description = "确认体重预警")]
        确认体重预警 = 2,

        /// <summary>
        /// 透析上机
        /// </summary>
        [Display(Description = "透析上机")]
        透析上机 = 3,

        /// <summary>
        /// 透析下机
        /// </summary>
        [Display(Description = "透析下机")]
        透析下机 = 4,
    }
}
