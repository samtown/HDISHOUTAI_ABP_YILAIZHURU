using System.ComponentModel.DataAnnotations;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// 测量方式枚举
    /// </summary>
    public enum MeasureTypeEnum
    {
        /// <summary>
        /// 两端
        /// </summary>
        [Display(Description = "透前")]
        透前 = 0,

        /// <summary>
        /// 透中
        /// </summary>
        [Display(Description = "透中")]
        透中 = 1,

        /// <summary>
        /// 透后
        /// </summary>
        [Display(Description = "透后")]
        透后 = 2,

        /// <summary>
        /// 日常
        /// </summary>
        [Display(Description = "日常")]
        日常 = 99
    }
}
