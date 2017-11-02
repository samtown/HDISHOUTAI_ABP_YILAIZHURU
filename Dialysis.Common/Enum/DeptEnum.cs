using System.ComponentModel.DataAnnotations;

namespace Dialysis.Common.Enum
{

    /// <summary>
    /// 医院科室枚举
    /// </summary>
    public enum DeptEnum
    {
        /// <summary>
        /// 肾内科
        /// </summary>
        [Display(Description = "肾内科")]
        Nephrology = 1
    }
}
