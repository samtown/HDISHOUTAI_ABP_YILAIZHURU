using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// 医护人员用户类型
    /// </summary>
    public enum UserTypeEnum
    {
        /// <summary>
        /// 医生
        /// </summary>
        [Display(Description = "医生")]
        Doctor = 0,

        /// <summary>
        /// 护士长
        /// </summary>
        [Display(Description = "护士长")]
        HeadNurse = 1,

        /// <summary>
        /// 护士
        /// </summary>
        [Display(Description = "护士")]
        Nurse = 2
    }
}
