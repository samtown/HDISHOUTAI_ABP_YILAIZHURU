using System.ComponentModel.DataAnnotations;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum SexEnum
    {
        /// <summary>
        /// 男
        /// </summary>
        [Display(Description = "男")]
        Male = 0,

        /// <summary>
        /// 女
        /// </summary>
        [Display(Description = "女")]
        Female = 1
    }
}
