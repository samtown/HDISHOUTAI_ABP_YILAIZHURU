using System.ComponentModel.DataAnnotations;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// App类型枚举
    /// </summary>
    public enum AppTypeEnum
    {
        /// <summary>
        /// 两端
        /// </summary>
        [Display(Description = "两端")]
        All = 0,

        /// <summary>
        /// 医生端
        /// </summary>
        [Display(Description = "医生端")]
        Doctor = 1,

        /// <summary>
        /// 患者端
        /// </summary>
        [Display(Description = "患者端")]
        Patient = 2,
    }
}
